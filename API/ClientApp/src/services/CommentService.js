import http from '../http-commen';
import authService from '../components/api-authorization/AuthorizeService';

const post = async (ideaId, content) => {
  const token = await authService.getAccessToken();
  let formdata = new FormData();
  formdata.append('ideaId', ideaId);
  formdata.append('content', content);
  return http.post(`/comment`, formdata, {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  });
};

export default {
  post
};
