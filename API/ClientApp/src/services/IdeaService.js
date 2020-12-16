import authService from '../components/api-authorization/AuthorizeService';
import http from '../http-commen';

const get = async (link, id) => {
  const token = await authService.getAccessToken();
  return http.get(`/idea/${id}`, {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` },
    params: { link: link }
  });
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

const getUserIdeasWithStatus = async (status) => {
  const token = await authService.getAccessToken();
  return http.get(`/idea/GetUserIdeasWithStatus`, {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` },
    params: { status: status }
  });
};

const getIdeasPeriod = (link, period) => {
  let formdata = new FormData();
  formdata.append('link', link);
  formdata.append('period', JSON.stringify(period));

  return http.post(`/idea/getideasperiod`, formdata);
};

const getPeriod = (link) => {
  return http.get(`/idea/getperiod`, {
    params: { link: link}
  });
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

const update = async (id, idea) => {
  const token = await authService.getAccessToken();
  return http.put(`/idea/${id}`, idea, {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  });
};

const remove = id => {
  return http.delete(`/idea/${id}`);
};

const removeAll = () => {
  return http.delete(`/idea`);
};

export default {
  get,
  getSiteIdeas,
  getUserIdeas,
  getUserIdeasWithStatus,
  getIdeasPeriod,
  getPeriod,
  getIdeaFileData,
  create,
  update,
  remove,
  removeAll
};
