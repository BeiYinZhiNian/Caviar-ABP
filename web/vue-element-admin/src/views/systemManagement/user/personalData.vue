<template>
  <div>
    <el-card class="box-card">
      <div slot="header" class="clearfix">
        <span>个人资料</span>
        <el-button style="float: right; padding: 3px 0" type="text" @click="$refs.modifyProfile.setFormData(formData)">修改个人资料</el-button>
      </div>
      <el-descriptions class="margin-top" :column="2" border>
        <el-descriptions-item>
          <template slot="label">
            <i class="el-icon-user" />
            用户名
          </template>
          {{ formData.name }}
        </el-descriptions-item>
        <el-descriptions-item>
          <template slot="label">
            <i class="el-icon-mobile-phone" />
            手机号
          </template>
          {{ formData.phoneNumber }}
        </el-descriptions-item>
        <el-descriptions-item>
          <template slot="label">
            <i class="el-icon-location-outline" />
            创建时间
          </template>
          {{ formData.creationTime }}
        </el-descriptions-item>
        <el-descriptions-item>
          <template slot="label">
            <i class="el-icon-message" />
            邮箱地址
          </template>
          {{ formData.emailAddress }}
        </el-descriptions-item>
        <el-descriptions-item>
          <template slot="label">
            <i class="el-icon-tickets" />
            角色
          </template>
          {{ formData.roleNames }}
        </el-descriptions-item>
        <el-descriptions-item v-if="tenant">
          <template slot="label">
            <i class="el-icon-office-building" />
            所在租户
          </template>
          {{ tenant.name }}
        </el-descriptions-item>
      </el-descriptions>
    </el-card>
    <modifyProfile ref="modifyProfile" :success="modifyCallback" />
  </div>
</template>
<script>
import { getInfo } from '@/api/user'
import modifyProfile from '@/views/systemManagement/user/modifyProfile.vue'
export default {
  components: { modifyProfile },
  data() {
    return {
      formData: {},
      tenant: {}
    }
  },
  created() {
    this.getUserInfo()
  },
  methods: {
    modifyCallback(formData) {
      this.formData = formData
    },
    getUserInfo() {
      getInfo().then((resopnse) => {
        this.formData = resopnse.result.user
        this.tenant = resopnse.result.tenant
      })
    }
  }
}
</script>
