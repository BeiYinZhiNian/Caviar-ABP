<template>
  <el-drawer
    title="日志详情"
    :visible.sync="drawer"
    :size="600"
  >
    <div style="margin-left: 15px;margin-right: 15px;">
      <el-descriptions :column="2">
        <el-descriptions-item label="操作人">{{ formData.name }}</el-descriptions-item>
        <el-descriptions-item label="手机号">{{ formData.phoneNumber }}</el-descriptions-item>
        <el-descriptions-item label="请求时间">{{ formData.executionTime }}</el-descriptions-item>
        <el-descriptions-item label="运行时长">{{ formData.executionDuration }}ms</el-descriptions-item>
        <el-descriptions-item label="请求服务">{{ formData.serviceName }}</el-descriptions-item>
        <el-descriptions-item label="请求方法">{{ formData.methodName }}</el-descriptions-item>
        <el-descriptions-item label="IP地址">{{ formData.clientIpAddress }}</el-descriptions-item>
        <el-descriptions-item label="客户端">
          <span v-if="!formData.clientName" type="success">浏览器</span>
          <span v-if="formData.clientName" type="danger">{{ formData.clientName }}</span>
        </el-descriptions-item>
      </el-descriptions>
      <el-divider />
      <el-form label-width="80px" :model="formData">
        <el-form-item label="请求结果">
          <el-tag v-if="!formData.exception" type="success">成功</el-tag>
          <el-tag v-if="formData.exception" type="danger">失败</el-tag>
        </el-form-item>
        <el-form-item label="参数">
          <span style="color: #909399;">{{ formData.parameters }}</span>
        </el-form-item>
        <el-form-item label="浏览器">
          <span style="color: #909399;">{{ formData.browserInfo }}</span>
        </el-form-item>
        <el-form-item v-if="formData.exception" label="异常提示">
          <span style="color: #606266;">{{ formData.exceptionMessage }}</span>
        </el-form-item>
        <el-form-item v-if="formData.exception" label="异常信息">
          <span style="color: #909399;">{{ formData.exception }}</span>
        </el-form-item>
      </el-form>
    </div>
  </el-drawer>
</template>
<script>
export default {
  data() {
    return {
      drawer: false,
      formData: {}
    }
  },
  methods: {
    setFormData(formData) {
      this.formData = formData
      this.drawer = true
    }
  }
}
</script>
