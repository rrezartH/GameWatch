import axios from 'axios';

axios.defaults.baseURL = 'https://localhost:7221/api/';

const responseBody = (response) =>  response.data;

const requests ={
    get: (url) => axios.get(url).then(responseBody),
    post: (url, body) => axios.post(url, body).then(responseBody),
    put: (url, body) => axios.put(url, body).then(responseBody),
    del: (url) => axios.delete(url).then(responseBody),
    patch: (url) => axios.patch(url).then(responseBody),
}

const Bizneset = {
    list: () => requests.get('/Biznesi/get-bizneset'),
    delete: (id) => requests.del(`Biznesi/fshij-biznesin/${id}`),
    create: (values) => requests.post('Biznesi/shto-biznes', values),
    update: (id, values) => requests.put(`Biznesi/update-biznesin/${id}`, values)
}
const Lokalet = {
    list: () => requests.get('/Lokali/get-lokalet'),
    delete: (id) => requests.del(`Lokali/fshij-lokalin/${id}`),
    create: (values) => requests.post('Lokali/shto-lokali', values),
    update: (id, values) => requests.put(`Lokali/update-lokali/${id}`, values)
}
const Konzolat = {
    list: () => requests.get('/Konzola/get-konzolat'),
    delete: (id) => requests.del(`Konzola/fshij-konzola/${id}`),
    create: (values) => requests.post('Konzola/shto-konzola', values),
    update: (id, values) => requests.put(`Konzola/update-konzola/${id}`, values)
}
const BiznesiKonzolat = {
    list: () => requests.get('/BiznesiKonzola/get-biznesi-konzolat'),
    delete: (id) => requests.del(`BiznesiKonzola/fshij-biznesi-konzola/${id}`),
    create: (values) => requests.post('BiznesiKonzola/shto-biznesi-konzola', values),
    update: (id, values) => requests.put(`BiznesiKonzola/update-biznesi-konzola/${id}`, values),
    listById: (id) => requests.get(`BiznesiKonzola/get-biznesi-konzola-by-lokali-id/${id}`)
}
const BizneziKonzolaVideolojat = {
    list: () => requests.get('/BizneziKonzolaVideoloja/get-biznesi-konzola-videolojat'),
    delete: (id) => requests.del(`BizneziKonzolaVideoloja/fshij-biznesi-konzola-videoloja/${id}`),
    create: (values) => requests.post('BizneziKonzolaVideoloja/shto-biznesi-konzola-videoloja', values),
    update: (id, values) => requests.put(`BizneziKonzolaVideoloja/update-biznesi-konzola-videoloja/${id}`, values)
}
const Cmimoret = {
    list: () => requests.get('/Cmimorja/get-cmimoret'),
    delete: (id) => requests.del(`Cmimorja/fshij-cmimore/${id}`),
    create: (values) => requests.post('Cmimorja/shto-cmimorja', values),
    update: (id, values) => requests.put(`Cmimorja/update-cmimore/${id}`, values)
}
const Faturat = {
    list: () => requests.get('/Fatura/get-faturat'),
    listLokaliNonClosed: (id) => requests.get(`Fatura/get-non-closed-faturat-e-lokalit/${id}`),
    create: (values) => requests.post('Fatura/shto-fatura', values),
    finalize: (id) => requests.put(`Fatura/finalizo-fatura/${id}`),
    update: (id, values) => requests.put(`Fatura/update-fatura/${id}`, values),
    preview: (id) => requests.get(`/Fatura/get-preview-fatura/${id}`)
}
const Users = {
    list: () => requests.get('/Users/get-users')
}
const VideoLojat = {
    list: () => requests.get('/VideoLoja/get-videlojat'),
    delete: (id) => requests.del(`VideoLoja/fshij-videoloje/${id}`),
    create: (values) => requests.post('VideoLoja/shto-videoloje', values),
    update: (id, values) => requests.put(`VideoLoja/update-videoloje/${id}`, values)
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