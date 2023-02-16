<template>
  <div>
    <el-card class="box-card">
      <div slot="header" class="clearfix">
        <span>个人信息</span>
      </div>
      <el-descriptions class="margin-top" :column="2" border>
        <el-descriptions-item>
          <template slot="label">
            <i class="el-icon-user" />
            用户名
          </template>
          {{ $store.getters.userInfo.name }}
        </el-descriptions-item>
        <el-descriptions-item>
          <template slot="label">
            <i class="el-icon-mobile-phone" />
            手机号
          </template>
          {{ $store.getters.userInfo.phoneNumber }}
        </el-descriptions-item>
        <el-descriptions-item>
          <template slot="label">
            <i class="el-icon-location-outline" />
            创建时间
          </template>
          {{ $store.getters.userInfo.creationTime }}
        </el-descriptions-item>
        <el-descriptions-item>
          <template slot="label">
            <i class="el-icon-office-building" />
            邮箱地址
          </template>
          {{ $store.getters.userInfo.emailAddress }}
        </el-descriptions-item>
        <el-descriptions-item>
          <template slot="label">
            <i class="el-icon-tickets" />
            角色
          </template>
          {{ $store.getters.roles }}
        </el-descriptions-item>
      </el-descriptions>
    </el-card>
  </div>
</template>
<script>
export default {
  data() {
    console.log(this.$store.getters.roles)
    return {

    }
  }
}
</script>
