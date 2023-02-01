const getters = {
  sidebar: state => state.app.sidebar,
  device: state => state.app.device,
  token: state => state.user.token,
  tenantId: state => state.user.tenantId,
  avatar: state => state.user.avatar,
  name: state => state.user.name,
  userInfo: state => state.user,
  roles: state => state.user.roles,
  visitedViews: state => state.tagsView.visitedViews,
  cachedViews: state => state.tagsView.cachedViews,
  permission_routes: state => state.permission.routes
}
export default getters
