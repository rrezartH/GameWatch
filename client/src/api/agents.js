import axios from 'axios';

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
const Lokalet = {
    list: () => requests.get('/Lokali/get-lokalet')
}
const Konzolat = {
    list: () => requests.get('/Konzola/get-konzolat')
}
const BiznesiKonzolat = {
    list: () => requests.get('/BiznesiKonzola/get-biznesi-konzolat')
}
const BizneziKonzolaVideolojat = {
    list: () => requests.get('/BizneziKonzolaVideoloja/get-biznesi-konzola-videolojat')
}
const Cmimoret = {
    list: () => requests.get('/Cmimorja/get-cmimoret')
}
const Faturat = {
    list: () => requests.get('/Fatura/get-faturat')
}
const Users = {
    list: () => requests.get('/Users/get-users')
}
const VideoLojat = {
    list: () => requests.get('/VideoLoja/get-videlojat')
}
const agent = {
    Bizneset,
    Lokalet,
    Konzolat,
    BiznesiKonzolat,
    BizneziKonzolaVideolojat,
    Cmimoret,
    Faturat,
    Users,
    VideoLojat,
}

export default agent