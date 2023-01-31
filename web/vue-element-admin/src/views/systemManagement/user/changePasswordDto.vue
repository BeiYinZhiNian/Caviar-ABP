<template>
  <el-dialog
    title="修改密码"
    append-to-body
    :visible.sync="dialogVisible"
    width="30%"
  >
    <el-form ref="form" :model="formData" :rules="rules" label-width="100px">
      <el-form-item label="当前密码" prop="currentPassword">
        <el-input v-model="formData.currentPassword" placeholder="请输入当前密码" show-password />
      </el-form-item>
      <el-form-item label="新密码" prop="newPassword">
        <el-input v-model="formData.newPassword" placeholder="请输入新密码" show-password />
      </el-form-item>
      <el-form-item label="确认新密码" prop="checkPass">
        <el-input v-model="formData.checkPass" placeholder="请确认新密码" show-password />
      </el-form-item>
    </el-form>
    <div slot="footer" class="dialog-footer">
      <el-button type="primary" :loading="loading" @click="submitForm">确定</el-button>
      <el-button :loading="loading" @click="dialogVisible = false">取消</el-button>
    </div>
  </el-dialog>
</template>
<script>
import { changePassword } from '@/api/userBasicInfo'
export default {
  data() {
    var validatePass2 = (rule, value, callback) => {
      if (value === '') {
        callback(new Error('请再次输入密码'))
      } else if (value !== this.formData.newPassword) {
        callback(new Error('两次输入密码不一致!'))
      } else {
        callback()
      }
    }
    return {
      dialogVisible: false,
      loading: false,
      formData: {},
      rules: {
        currentPassword: [
          { required: true, message: '请输入当前密码', trigger: 'blur' },
          { min: 6, max: 20, message: '长度在 6 到 20 个字符', trigger: 'blur' }
        ],
        newPassword: [
          { required: true, message: '请输入新密码', trigger: 'blur' },
          { min: 6, max: 20, message: '长度在 6 到 20 个字符', trigger: 'blur' }
        ],
        checkPass: [
          { validator: validatePass2, required: true, trigger: 'blur' }
        ]
      }
    }
  },
  methods: {
    setFormData() {
      this.dialogVisible = true
    },
    submitForm() {
      this.$refs.form.validate((valid) => {
        if (valid) {
          this.loading = true
          changePassword(this.formData).then(response => {
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
