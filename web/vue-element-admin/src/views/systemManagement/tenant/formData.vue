<template>
  <el-dialog :title="title" :visible.sync="dialogVisible" width="800px">
    <el-form ref="form" :model="formData" :rules="rules" label-width="120px">
      <el-form-item label="租户账号" prop="tenancyName" style="width: 400px;">
        <el-input v-model="formData.tenancyName" maxlength="20" placeholder="请输入租户账号" show-word-limit />
      </el-form-item>
      <el-form-item label="租户名称" prop="name" style="width: 400px;">
        <el-input v-model="formData.name" maxlength="20" placeholder="请输入租户名称" show-word-limit />
      </el-form-item>
      <el-form-item v-if="isCreateOrUpdate" label="管理员手机号" prop="phoneNumber" style="width: 400px;">
        <el-input v-model="formData.phoneNumber" maxlength="11" placeholder="请输入管理员手机号" show-word-limit />
      </el-form-item>
      <el-form-item label="启用状态">
        <el-radio-group v-model="formData.isActive">
          <el-radio-button :label="true">启用</el-radio-button>
          <el-radio-button :label="false">禁用</el-radio-button>
        </el-radio-group>
      </el-form-item>
      <el-form-item v-if="isCreateOrUpdate" label="连接字符串" prop="connectionString" style="width: 500px;">
        <el-input v-model="formData.connectionString" maxlength="1024" type="textarea" placeholder="请输入连接字符串" show-word-limit />
      </el-form-item>
    </el-form>
    <div slot="footer" class="dialog-footer">
      <el-button type="primary" :loading="loading" @click="submitForm">确定</el-button>
      <el-button :loading="loading" @click="dialogVisible = false">取消</el-button>
    </div>
  </el-dialog>
</template>
<script>
import { createData, updateData } from '@/api/tenant'
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
      rules: {
        tenancyName: [
          { required: true, message: '请输入租户名称', trigger: 'blur' }
        ],
        name: [
          { required: true, message: '请输入租户名称', trigger: 'blur' }
        ],
        phoneNumber: [
          { required: true, message: '请输入管理员手机号', trigger: 'blur' }
        ]
      }
    }
  },
  methods: {
    setFormData(formData) {
      this.dialogVisible = true
      if (formData) {
        this.isCreateOrUpdate = false
        this.title = '修改租户'
        this.formData = Object.assign({}, formData)
      } else {
        this.title = '创建租户'
        this.isCreateOrUpdate = true
        this.formData = {
          isActive: true
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
