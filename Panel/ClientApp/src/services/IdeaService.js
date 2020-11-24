import http from '../http-commen';

const getAll = () => {
  return http.get("/idea");
};

const get = id => {
  return http.get(`/idea/${id}`);
};

const create = data => {
  return http.post("/idea", data);
};

const update = (id, data) => {
  return http.put(`/idea/${id}`, data);
};

const remove = id => {
  return http.delete(`/idea/${id}`);
};

const removeAll = () => {
  return http.delete(`/idea`);
};

const findByTitle = title => {
  return http.get(`/idea?title=${title}`);
};

export default {
  getAll,
  get,
  create,
  update,
  remove,
  removeAll,
  findByTitle
};
