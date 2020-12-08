import http from '../http-commen';

const getAll = () => {
  return http.get("/site");
};

const get = id => {
  return http.get(`/site/${id}`);
};

const create = data => {
  return http.post("/site", data);
};

const update = (id, data) => {
  return http.put(`/site/${id}`, data);
};

const remove = id => {
  return http.delete(`/site/${id}`);
};

const removeAll = () => {
  return http.delete(`/site`);
};

const findByLink = link => {
  return http.get(`site/getbylink/${link}`);
};

export default {
  getAll,
  get,
  create,
  update,
  remove,
  removeAll,
  findByLink
};
