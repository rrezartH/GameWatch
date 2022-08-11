import axios, { AxiosResponse } from 'axios';

axios.defaults.baseURL = 'https://localhost:7221/api/';

const responseBody = (response) =>  response.data;

const requests ={
    get: (url) => axios.get(url).then(responseBody),
    post: (url, body) => axios.post(url, body).then(responseBody),
    put: (url, body) => axios.put(url, body).then(responseBody),
    del: (url) => axios.delete(url).then(responseBody),
}

const Bizneset = {
    list: () => requests.get('/Biznesi/get-bizneset')
}

const agent = {
    Bizneset
}

export default agent