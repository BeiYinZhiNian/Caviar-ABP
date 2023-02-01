<template>
  <div style="min-width:1085px;background:linear-gradient(130deg, #0f75ff 40%, #2ddcd3  100%); overflow: hidden;height: 100%">
    <el-row type="flex" justify="center" align="middle" style=" height:100%;">

      <el-col style="width:1085px;">

        <el-card class="um-loginbox">

          <div class="um-loginleft"><span><img src="@/assets/images/logo-login.png" height="30%" width="30%"></span></div>

          <div class="um-loginright">

            <div class="um-systemname">Caviar后台管理系统</div>

            <el-row class="um-login">
              <tenantSwitch ref="tenantSwitch" />
              <el-form ref="loginForm" :model="loginForm" :rules="loginRules" class="login-form" auto-complete="on" label-position="left">
                <el-col class="um-logincol">手机号</el-col>
                <el-form-item prop="username">
                  <el-input
                    ref="username"
                    v-model="loginForm.username"
                    name="username"
                    type="text"
                    tabindex="1"
                    auto-complete="on"
                    placeholder="请输入手机号"
                    clearable
                    prefix-icon="el-icon-user"
                  />
                </el-form-item>
                <el-col class="um-logincol">密码</el-col>
                <el-form-item prop="password"><el-input
                  :key="passwordType"
                  ref="password"
                  v-model="loginForm.password"
                  :type="passwordType"
                  placeholder="请输入密码"
                  name="password"
                  tabindex="2"
                  auto-complete="on"
                  show-password
                  prefix-icon="el-icon-lock"
                  @keyup.enter.native="handleLogin"
                /></el-form-item>

                <el-col class="um-loginbtn"><el-button type="primary" round :loading="loading" @click.native.prevent="handleLogin">登录</el-button></el-col>
              </el-form>
            </el-row>

          </div>

        </el-card>

      </el-col>
    </el-row>
  </div>
</template>

<script>
import '@/styles/uimaker.css'
import tenantSwitch from '@/views/login/tenantSwitch.vue'
export default {
  name: 'Login',
  components: { tenantSwitch },
  data() {
    return {
      loginForm: {
        username: '13034734324',
        password: '123qwe'
      },
      loginRules: {
        username: [{ required: true, trigger: 'blur', message: '请输入账号' }],
        password: [{ required: true, trigger: 'blur', message: '请输入密码' }]
      },
      loading: false,
      passwordType: 'password',
      redirect: undefined
    }
  },
  watch: {
    $route: {
      handler: function(route) {
        this.redirect = route.query && route.query.redirect
      },
      immediate: true
    }
  },
  methods: {
    showPwd() {
      if (this.passwordType === 'password') {
        this.passwordType = ''
      } else {
        this.passwordType = 'password'
      }
      this.$nextTick(() => {
        this.$refs.password.focus()
      })
    },
    handleLogin() {
      this.$refs.loginForm.validate(valid => {
        if (valid) {
          this.loading = true
          this.$store.dispatch('user/login', this.loginForm).then(() => {
            this.$router.push({ path: this.redirect || '/' })
            this.loading = false
          }).catch(() => {
            this.loading = false
          })
        } else {
          console.log('error submit!!')
          return false
        }
      })
    }
  }
}
</script>

<style lang="scss">
/* 修复input 背景不协调 和光标变色 */
/* Detail see https://github.com/PanJiaChen/vue-element-admin/pull/927 */

$bg:#283443;
$light_gray:#fff;
$cursor: #fff;

@supports (-webkit-mask: none) and (not (cater-color: $cursor)) {
  .login-container .el-input input {
    color: $cursor;
  }
}

/* reset element-ui css */
.login-container {
  .el-input {
    display: inline-block;
    height: 47px;
    width: 85%;

    input {
      background: transparent;
      border: 0px;
      -webkit-appearance: none;
      border-radius: 0px;
      padding: 12px 5px 12px 15px;
      color: $light_gray;
      height: 47px;
      caret-color: $cursor;

      &:-webkit-autofill {
        box-shadow: 0 0 0px 1000px $bg inset !important;
        -webkit-text-fill-color: $cursor !important;
      }
    }
  }

  .el-form-item {
    border: 1px solid rgba(255, 255, 255, 0.1);
    background: rgba(0, 0, 0, 0.1);
    border-radius: 5px;
    color: #454545;
  }
}
</style>

<style lang="scss" scoped>
$bg:#2d3a4b;
$dark_gray:#889aa4;
$light_gray:#eee;

.login-container {
  min-height: 100%;
  width: 100%;
  background-color: $bg;
  overflow: hidden;

  .login-form {
    position: relative;
    width: 520px;
    max-width: 100%;
    padding: 160px 35px 0;
    margin: 0 auto;
    overflow: hidden;
  }

  .tips {
    font-size: 14px;
    color: #fff;
    margin-bottom: 10px;

    span {
      &:first-of-type {
        margin-right: 16px;
      }
    }
  }

  .svg-container {
    padding: 6px 5px 6px 15px;
    color: $dark_gray;
    vertical-align: middle;
    width: 30px;
    display: inline-block;
  }

  .title-container {
    position: relative;

    .title {
      font-size: 26px;
      color: $light_gray;
      margin: 0px auto 40px auto;
      text-align: center;
      font-weight: bold;
    }
  }

  .show-pwd {
    position: absolute;
    right: 10px;
    top: 7px;
    font-size: 16px;
    color: $dark_gray;
    cursor: pointer;
    user-select: none;
  }
}
</style>
