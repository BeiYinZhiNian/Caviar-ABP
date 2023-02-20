import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

/* Layout */
import Layout from '@/layout'

/**
 * Note: sub-menu only appear when route children.length >= 1
 * Detail see: https://panjiachen.github.io/vue-element-admin-site/guide/essentials/router-and-nav.html
 *
 * hidden: true                   if set true, item will not show in the sidebar(default is false)
 * alwaysShow: true               if set true, will always show the root menu
 *                                if not set alwaysShow, when item has more than one children route,
 *                                it will becomes nested mode, otherwise not show the root menu
 * redirect: noRedirect           if set noRedirect will no redirect in the breadcrumb
 * name:'router-name'             the name is used by <keep-alive> (must set!!!)
 * meta : {
    roles: ['admin','editor']    control the page roles (you can set multiple roles)
    title: 'title'               the name show in sidebar and breadcrumb (recommend set)
    icon: 'svg-name'/'el-icon-x' the icon show in the sidebar
    breadcrumb: false            if set false, the item will hidden in breadcrumb(default is true)
    activeMenu: '/example/list'  if set path, the sidebar will highlight the path you set
  }
 */

/**
 * constantRoutes
 * a base page that does not have permission requirements
 * all roles can be accessed
 */
export const constantRoutes = [
  {
    path: '/login',
    component: () => import('@/views/login/index'),
    hidden: true
  },

  {
    path: '/404',
    component: () => import('@/views/404'),
    hidden: true
  },
  {
    path: '/',
    component: Layout,
    redirect: '/dashboard',
    children: [{
      path: 'dashboard',
      name: 'Dashboard',
      component: () => import('@/views/dashboard/index'),
      meta: { title: '首页', icon: 'dashboard', affix: true }
    }]
  },
  {
    path: '/personalData',
    component: Layout,
    hidden: true,
    children: [{
      path: 'index',
      name: 'index',
      component: () => import('@/views/systemManagement/user/personalData'),
      meta: { title: '个人资料' }
    }]
  }
]

const createRouter = () => new Router({
  // mode: 'history', // require service support
  scrollBehavior: () => ({ y: 0 }),
  routes: constantRoutes
})

const router = createRouter()

// Detail see: https://github.com/vuejs/vue-router/issues/1234#issuecomment-357941465
export function resetRouter() {
  const newRouter = createRouter()
  router.matcher = newRouter.matcher // reset router
}

export default router

// 异步挂载的路由
// 动态需要根据权限加载的路由表
export const asyncRoutes = [
  {
    path: '/systemManagement',
    component: Layout,
    alwaysShow: true,
    redirect: 'noRedirect',
    name: 'systemManagement',
    meta: { title: '系统设置', icon: 'el-icon-setting' },
    children: [
      {
        path: 'user',
        name: 'user',
        component: () => import('@/views/systemManagement/user/index'),
        meta: { title: '用户管理', icon: 'el-icon-user', roles: ['Pages_Users'] }
      },
      {
        path: 'role',
        name: 'role',
        component: () => import('@/views/systemManagement/role/index'),
        meta: { title: '角色管理', icon: 'el-icon-s-custom', roles: ['Pages_Roles'] }
      },
      {
        path: 'tenant',
        name: 'tenant',
        component: () => import('@/views/systemManagement/tenant/index'),
        meta: { title: '租户管理', icon: 'el-icon-discount', roles: ['Pages_Tenants'] }
      },
      {
        path: 'journal',
        name: 'journal',
        component: () => import('@/views/systemManagement/journal/index'),
        redirect: 'noRedirect',
        meta: { title: '日志管理', icon: 'el-icon-edit-outline' },
        children: [
          {
            path: 'auditLog',
            name: 'auditLog',
            component: () => import('@/views/systemManagement/journal/auditLog'),
            meta: { title: '审计日志', icon: 'el-icon-document', roles: ['Pages_Users'] }
          },
          {
            path: 'loginlog',
            name: 'loginlog',
            component: () => import('@/views/systemManagement/journal/loginLog'),
            meta: { title: '登录日志', icon: 'el-icon-document-remove', roles: ['Pages_Users'] }
          }
        ]
      }
    ]
  },
  { path: '*', redirect: '/404', hidden: true }
]
