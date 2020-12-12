import http from '../http-commen';

const getAll = () => {
  return http.get("/idea");
};

const get = id => {
  return http.get(`/idea/${id}`);
};

const getSiteIdeas = id => {
  return http.get(`/idea/getsiteideas`, { params: { siteId: id } });
};

const getIdeasPeriod = period => {
  return http.post(`/idea/getideasperiod`, period);
};

const getPeriod = () => {
  return http.get(`/idea/getperiod`);
};

const create = data => {
  const config = {
    headers: { 'content-type': 'multipart/form-data' }
  }
  return http.post("/idea", data, config);
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
  getSiteIdeas,
  getIdeasPeriod,
  getPeriod,
  create,
  update,
  remove,
  removeAll,
  findByTitle
};
