import Cookies from 'js-cookie'

const TokenKey = 'authorization'
const tenantIdCookieName = 'Abp.TenantId'
export function getToken() {
  return Cookies.get(TokenKey)
}

export function setToken(token) {
  return Cookies.set(TokenKey, token)
}

export function removeToken() {
  return Cookies.remove(TokenKey)
}

export function setTenantId(value) {
  return Cookies.set(tenantIdCookieName, value)
}

export function getTenantId() {
  return Cookies.get(tenantIdCookieName)
}

export function removeTenantId() {
  return Cookies.remove(tenantIdCookieName)
}
