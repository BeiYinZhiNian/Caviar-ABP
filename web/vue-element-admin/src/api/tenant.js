import request from '@/utils/request'
import qs from 'qs'
const baseUri = '/services/app/tenant'

export function createData(data) {
  return request({
    url: baseUri + '/create',
    method: 'post',
    data: data
  })
}

export function updateData(data) {
  return request({
    url: baseUri + '/update',
    method: 'put',
    data: data
  })
}

export function deleteData(data) {
  return request({
    url: baseUri + '/delete',
    method: 'delete',
    params: data
  })
}

export function getAll(data) {
  return request({
    url: baseUri + '/getAll',
    method: 'get',
    params: data,
    paramsSerializer: params => {
      return qs.stringify(params, {
        indices: false
      })
    }
  })
}
