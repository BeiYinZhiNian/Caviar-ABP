import request from '@/utils/request'
const baseUri = '/services/app/account'

export function isTenantAvailable(data) {
  return request({
    url: baseUri + '/isTenantAvailable',
    method: 'post',
    data: data
  })
}

export function register(data) {
  return request({
    url: baseUri + '/register',
    method: 'post',
    data: data
  })
}
