<template>
  <el-dialog :title="title" :visible.sync="dialogVisible">
    <el-form ref="form" :model="formData" :rules="rules" label-width="90px">
      <el-form-item label="启用状态">
        <el-radio-group v-model="formData.isActive">
          <el-radio-button :label="true">启用</el-radio-button>
          <el-radio-button :label="false">禁用</el-radio-button>
        </el-radio-group>
      </el-form-item>
      <el-row>
        <el-col :span="11">
          <el-form-item label="账号名称" prop="name">
            <el-input v-model="formData.name" maxlength="20" placeholder="请输入账号名称" show-word-limit />
          </el-form-item>
        </el-col>
        <el-col :span="11">
          <el-form-item label="手机号" prop="phoneNumber">
            <el-input v-model="formData.phoneNumber" placeholder="请输入手机号" maxlength="11" show-word-limit />
          </el-form-item>
        </el-col>
      </el-row>
      <el-row>
        <el-col :span="11">
          <el-form-item v-if="isCreateOrUpdate" label="密码" prop="password">
            <el-input v-model="formData.password" placeholder="请输入密码" show-password style="width: 250px;" />
          </el-form-item>
        </el-col>
      </el-row>
      <el-row>
        <el-col :span="11">
          <el-form-item label="邮箱地址" prop="emailAddress">
            <el-input v-model="formData.emailAddress" placeholder="请输入邮箱地址" maxlength="100" show-word-limit />
          </el-form-item>
        </el-col>
        <el-col :span="11">
          <el-form-item label="角色">
            <el-select
              v-model="formData.roleNames"
              multiple
              collapse-tags
              placeholder="请选择"
            >
              <el-option
                v-for="item in rolesOption"
                :key="item.id"
                :label="item.name"
                :value="item.name"
              />
            </el-select>
          </el-form-item>
        </el-col>
      </el-row>

    </el-form>
    <div slot="footer" class="dialog-footer">
      <el-button type="primary" :loading="loading" @click="submitForm">确定</el-button>
      <el-button :loading="loading" @click="dialogVisible = false">取消</el-button>
    </div>
  </el-dialog>
</template>
<script>
import { createData, updateData } from '@/api/user'
import { getRoles } from '@/api/role'
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
      rolesOption: [],
      rules: {
        name: [
          { required: true, message: '请输入账号名称', trigger: 'blur' }
        ],
        phoneNumber: [
          { required: true, message: '请输入手机号', trigger: 'blur' }
        ],
        password: [
          { required: true, message: '请输入密码', trigger: 'blur' }
        ]
      }
    }
  },
  methods: {
    setFormData(formData) {
      getRoles().then(response => {
        this.rolesOption = response.result.items
      })
      this.dialogVisible = true
      if (formData) {
        this.isCreateOrUpdate = false
        this.title = '修改账号'
        this.formData = Object.assign({}, formData)
      } else {
        this.title = '创建账号'
        this.isCreateOrUpdate = true
        this.formData = {
          isActive: true,
          roleNames: []
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
