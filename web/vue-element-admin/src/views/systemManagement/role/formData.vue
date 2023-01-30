<template>
  <el-dialog :title="title" :visible.sync="dialogVisible">
    <el-form ref="form" :model="formData" :rules="rules" label-width="90px">
      <el-row>
        <el-col :span="11">
          <el-form-item label="角色名称" prop="name">
            <el-input v-model="formData.name" maxlength="20" placeholder="请输入角色名称" show-word-limit />
          </el-form-item>
        </el-col>
      </el-row>
      <el-form-item label="权限">
        <el-checkbox-group v-model="formData.grantedPermissions">
          <el-checkbox v-for="permission in permissionsOption" :key="permission.name" :label="permission.name">{{ permission.displayName }}</el-checkbox>
        </el-checkbox-group>
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
import { createData, updateData, getAllPermissions } from '@/api/role'
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
      permissionsOption: [],
      rules: {
        name: [
          { required: true, message: '请输入角色名称', trigger: 'blur' }
        ]
      }
    }
  },
  methods: {
    setFormData(formData) {
      getAllPermissions().then(response => {
        this.permissionsOption = response.result.items
      })
      this.dialogVisible = true
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
