import request from '@/utils/request'
import qs from 'qs'
const baseUri = '/services/app/user'

export function get(data) {
  return request({
    url: baseUri + '/get',
    method: 'get',
    params: data
  })
}

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

export function login(data) {
  return request({
    url: '/tokenAuth/authenticate',
    method: 'post',
    data
  })
}

export function getInfo(token) {
  return request({
    url: '/services/app/session/getCurrentLoginInformations',
    method: 'get'
  })
}

