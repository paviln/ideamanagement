import http from '../http-commen';

const get = id => {
  return http.get(`/site/${id}`);
};

const findByLink = link => {
  return http.get(`site/getbylink/${link}`);
};

export default {
  get,
  findByLink
};
