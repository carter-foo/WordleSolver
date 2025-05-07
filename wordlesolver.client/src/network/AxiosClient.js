import axios from 'axios';

class AxiosClient {
  constructor(baseURL) {
    this.client = axios.create({
      baseURL: baseURL,
    });
  }

  async get(endpoint, params = {}) {
    try {
      const response = await this.client.get(endpoint, { params });
      return response.data;
    } catch (error) {
      console.error('GET request failed:', error);
      throw error;
    }
  }

  async post(endpoint, data = {}, config = {}) {
    try {
      const response = await this.client.post(endpoint, data, config);
      return response.data;
    } catch (error) {
      console.error('POST request failed:', error);
      throw error;
    }
  }
}

export default AxiosClient;