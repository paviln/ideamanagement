import authService from '../components/api-authorization/AuthorizeService';
import http from '../http-commen';

const getAll = () => {
  return http.get("/idea");
};

const get = id => {
  return http.get(`/idea/${id}`);
};

const getSiteIdeas = link => {
  return http.get(`/idea/getsiteideas`, { params: { link: link } });
};

const getUserIdeas = async () => {
  const token = await authService.getAccessToken();
  return http.get(`/idea/getuserideas`, {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  });
};

const getSiteIdeasUnderReview = link => {
  return http.get(`/idea/getsiteideasunderreview`, { params: { link: link } });
};

const getIdeasPeriod = (siteId, period) => {
  let formdata = new FormData();
  formdata.append('siteId', siteId);
  formdata.append('period', JSON.stringify(period));

  return http.post(`/idea/getideasperiod`, formdata);
};

const getPeriod = () => {
  return http.get(`/idea/getperiod`);
};

const getIdeaFileData = id => {
  const config = {
    responseType: 'blob', 
    timeout: 30000, 
    params: { fileId: id },
  }

  return http.get(`/idea/getideafiledata`, config);
};

const create = data => {
  const config = {
    headers: { 'content-type': 'multipart/form-data' }
  }
  return http.post("/idea", data, config);
};

const postIdeaComment = data => {
  return http.post("/idea/postideacomment", data);
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
  getUserIdeas,
  getSiteIdeasUnderReview,
  getIdeasPeriod,
  getPeriod,
  getIdeaFileData,
  create,
  postIdeaComment,
  update,
  remove,
  removeAll,
  findByTitle
};
