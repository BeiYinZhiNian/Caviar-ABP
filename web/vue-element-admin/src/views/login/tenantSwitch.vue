<template>
  <div>
    <el-button type="text" @click="openTenant">{{ tenantData == undefined ? "未选择租户": "当前租户：" + tenantData.name }}</el-button>
  </div>
</template>
<script>
import { isTenantAvailable } from '@/api/account'
import { setTenantId, removeTenantId } from '@/utils/auth'
export default {
  data() {
    return {
      loading: false,
      tenantData: this.$store.getters.userInfo.tenant
    }
  },
  methods: {
    openTenant() {
      this.$prompt('请输入租户账号', '选择租户', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        inputPlaceholder: '请输入租户账号，留空切换为主机'
      }).then(({ value }) => {
        console.log(value)
        if (value === null) {
          removeTenantId()
          location.reload()
          return
        } else {
          this.isTenantAvailable({ tenancyName: value })
        }
      }).catch(() => {

      })
    },
    isTenantAvailable(tenant) {
      this.loading = true
      isTenantAvailable(tenant).then(response => {
        const { result } = response
        switch (result.state) {
          case 1:
            setTenantId(result.tenantId)
            location.reload()
            return
          case 2:
            this.$message({
              type: 'error',
              message: '租户未激活'
            })
            break
          case 3:
            this.$message({
              type: 'error',
              message: '不存在该租户：' + tenant.tenancyName
            })
            break
        }
        this.loading = false
      }).catch(() => {
        this.loading = false
      })
    }
  }
}
</script>
