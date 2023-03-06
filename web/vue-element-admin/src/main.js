import Vue from 'vue'

import 'normalize.css/normalize.css' // A modern alternative to CSS resets

import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
// 引入自定义组件
import components from '@/components/index.js'
import '@/styles/index.scss' // global css
import '@/styles/caviar.scss'

import App from './App'
import store from './store'
import router from './router'
import permission from '@/directive/permission/index.js' // 权限判断指令
import checkPermission from '@/utils/permission.js' // 权限判断函数

import '@/icons' // icon
import '@/permission' // permission control

/**
 * If you don't want to use mock-server
 * you want to use MockJs for mock api
 * you can execute: mockXHR()
 *
 * Currently MockJs will be used in the production environment,
 * please remove it before going online ! ! !
 */
if (process.env.NODE_ENV === 'production') {
  const { mockXHR } = require('../mock')
  mockXHR()
}

// 修改 el-dialog 默认点击遮照不关闭
ElementUI.Dialog.props.closeOnClickModal.default = false
// set ElementUI lang to EN
// Vue.use(ElementUI, { locale })
// 如果想要中文版 element-ui，按如下方式声明
Vue.use(ElementUI)
// vue导入
Vue.use(components)
Vue.config.productionTip = false
// 权限验证指令
Vue.use(permission)
Vue.prototype.checkPermission = checkPermission
new Vue({
  el: '#app',
  router,
  store,
  render: h => h(App)
})
