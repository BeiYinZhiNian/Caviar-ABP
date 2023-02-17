import request from '@/utils/request'
import qs from 'qs'
const baseUri = '/services/app/journal'

export function getAllUserLoginLog(data) {
  return request({
    url: baseUri + '/getAllUserLoginLog',
    method: 'get',
    params: data,
    paramsSerializer: params => {
      return qs.stringify(params, {
        indices: false
      })
    }
  })
}

