<template>
  <el-dialog :title="title" :visible.sync="dialogVisible" class="abow-dialog">
    <el-form ref="form" :model="formData" :rules="rules" label-width="90px">
      <el-row>
        <el-col :span="11">
          <el-form-item label="角色名称" prop="name">
            <el-input v-model="formData.name" maxlength="20" placeholder="请输入角色名称" show-word-limit />
          </el-form-item>
        </el-col>
      </el-row>
      <el-form-item label="权限">
        <el-tree ref="tree" :data="permissionData" show-checkbox check-strictly node-key="nodeKey" :default-checked-keys="formData.grantedPermissions" />
      </el-form-item>
      <el-form-item label="备注">
        <el-input
          v-model="formData.description"
          type="textarea"
          :rows="2"
          maxlength="50"
          show-word-limit
          placeholder="请输入备注信息"
        />
      </el-form-item>
    </el-form>
    <div slot="footer" class="dialog-footer">
      <el-button type="primary" :loading="loading" @click="submitForm">确定</el-button>
      <el-button :loading="loading" @click="dialogVisible = false">取消</el-button>
    </div>
  </el-dialog>
</template>
<script>
import { createData, updateData } from '@/api/role'
export default {
  props: {
    success: {
      type: Function,
      default: null
    }
  },
  data() {
    return {
      title: '',
      loading: false,
      isCreateOrUpdate: true,
      dialogVisible: false,
      formData: {},
      permissionData: [],
      rules: {
        name: [
          { required: true, message: '请输入角色名称', trigger: 'blur' }
        ]
      }
    }
  },
  methods: {
    treefixed(permissionData, arr, value, index) {
      let exist = false
      permissionData.forEach(item => {
        if (item.key === arr[index]) {
          exist = true
          if (arr.length - 1 === index) {
          // 位置找到
            item.label = value.item2
          } else {
            this.treefixed(item.children, arr, value, index + 1)
          }
        }
      })
      if (!exist) {
        const item = {
          label: '',
          key: arr[index],
          nodeKey: '',
          children: []
        }
        permissionData.push(item)
        if (arr.length - 1 === index) {
        // 位置找到
          item.label = value.item2
        } else {
          this.treefixed(item.children, arr, value, index + 1)
        }
      }
    },
    setFormData(formData) {
      this.dialogVisible = true
      const permissions = this.$store.getters.userInfo.permissions
      const permissionData = []
      permissions.forEach(element => {
        const node_keys = element.item1.split('_')
        this.treefixed(permissionData, node_keys, element, 0)
      })
      this.permissionData = permissionData
      if (formData) {
        this.isCreateOrUpdate = false
        this.title = '修改角色'
        this.formData = Object.assign({}, formData)
      } else {
        this.title = '创建角色'
        this.isCreateOrUpdate = true
        this.formData = {
          grantedPermissions: []
        }
      }
    },
    submitForm() {
      this.$refs.form.validate((valid) => {
        if (valid) {
          this.loading = true
          this.formData.grantedPermissions = this.$refs.tree.getCheckedKeys()
          const action = this.isCreateOrUpdate ? createData : updateData
          action(this.formData).then(response => {
            this.$message({
              message: '操作成功',
              type: 'success'
            })
            if (this.success) {
              this.success()
            }
            this.dialogVisible = false
          }).finally(() => {
            this.loading = false
          })
        }
      })
    }
  }
}
</script>
