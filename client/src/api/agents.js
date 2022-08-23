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
    list: () => requests.get('/Biznesi/get-bizneset'),
    delete: (id) => requests.del(`Biznesi/fshij-biznesin/${id}`),
    create: (values) => requests.post('Biznesi/shto-biznes', values)
}
const Lokalet = {
    list: () => requests.get('/Lokali/get-lokalet'),
    delete: (id) => requests.del(`Lokali/fshij-lokalin/${id}`),
    create: (values) => requests.post('Lokali/shto-lokali', values)
}
const Konzolat = {
    list: () => requests.get('/Konzola/get-konzolat'),
    delete: (id) => requests.del(`Konzola/fshij-konzola/${id}`),
    create: (values) => requests.post('Konzola/shto-konzola', values)
}
const BiznesiKonzolat = {
    list: () => requests.get('/BiznesiKonzola/get-biznesi-konzolat'),
    delete: (id) => requests.del(`BiznesiKonzola/fshij-biznesi-konzola/${id}`),
    create: (values) => requests.post('BiznesiKonzola/shto-biznesi-konzola', values)
}
const BizneziKonzolaVideolojat = {
    list: () => requests.get('/BizneziKonzolaVideoloja/get-biznesi-konzola-videolojat'),
    delete: (id) => requests.del(`BizneziKonzolaVideoloja/fshij-biznesi-konzola-videoloja/${id}`),
    create: (values) => requests.post('BizneziKonzolaVideoloja/shto-biznesi-konzola-videoloja', values)
}
const Cmimoret = {
    list: () => requests.get('/Cmimorja/get-cmimoret'),
    delete: (id) => requests.del(`Cmimorja/fshij-cmimore/${id}`),
    create: (values) => requests.post('Cmimorja/shto-cmimorja', values)
}
const Faturat = {
    list: () => requests.get('/Fatura/get-faturat'),
    create: (values) => requests.post('Fatura/shto-fatura', values)
}
const Users = {
    list: () => requests.get('/Users/get-users')
}
const VideoLojat = {
    list: () => requests.get('/VideoLoja/get-videlojat'),
    delete: (id) => requests.del(`VideoLoja/fshij-videoloje/${id}`),
    create: (values) => requests.post('VideoLoja/shto-videoloje', values)
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