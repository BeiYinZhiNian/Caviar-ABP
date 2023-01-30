// 导入刚刚定义的组件
import TableBool from './TableBool/index.vue'
// 初始化
const component = {
  install: function(Vue) {
    // 定义全局组件，如果还有更多的组件，就在这写
    Vue.component('tableBool', TableBool)
  }
}
// 暴露组件
export default component
