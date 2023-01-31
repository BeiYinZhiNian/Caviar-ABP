import request from '@/utils/request'
const baseUri = '/services/app/userBasicInfo'

export function changePassword(data) {
  return request({
    url: baseUri + '/changePassword',
    method: 'post',
    data
  })
}
