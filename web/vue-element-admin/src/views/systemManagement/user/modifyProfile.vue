<template>
  <el-dialog :title="title" :visible.sync="dialogVisible">
    <el-form ref="form" :model="formData" :rules="rules" label-width="90px">
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
      <el-form-item label="邮箱地址" prop="emailAddress">
        <el-input v-model="formData.emailAddress" placeholder="请输入邮箱地址" maxlength="100" show-word-limit />
      </el-form-item>
    </el-form>
    <div slot="footer" class="dialog-footer">
      <el-button type="primary" :loading="loading" @click="submitForm">确定</el-button>
      <el-button :loading="loading" @click="dialogVisible = false">取消</el-button>
    </div>
  </el-dialog>
</template>
<script>
import { modify } from '@/api/user'
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
      dialogVisible: false,
      formData: {},
      rolesOption: [],
      rules: {
        name: [
          { required: true, message: '请输入账号名称', trigger: 'blur' }
        ],
        phoneNumber: [
          { required: true, message: '请输入手机号', trigger: 'blur' }
        ]
      }
    }
  },
  methods: {
    setFormData(formData) {
      this.dialogVisible = true
      this.title = '修改个人资料'
      this.formData = Object.assign({}, formData)
    },
    submitForm() {
      this.$refs.form.validate((valid) => {
        if (valid) {
          this.loading = true
          modify(this.formData).then(response => {
            this.$message({
              message: '操作成功',
              type: 'success'
            })
            if (this.success) {
              this.success(response.result)
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
