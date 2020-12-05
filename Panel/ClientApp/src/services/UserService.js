import http from '../http-commen';
import authService from '../components/api-authorization/AuthorizeService';

const getSite = async () => {
  const token = await authService.getAccessToken();
  return http.get(`/applicationuser/getsite`, {
    headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
  });
};

export default {
  getSite
};
