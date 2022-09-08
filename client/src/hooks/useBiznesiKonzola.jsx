import { useQuery } from "react-query";
import agent from "../api/agents"

//Query keys
export const BIZNESI_KONZOLA_KEY = "biznesiKonzola";
export const NON_CLOSED_FATURAT = "nonClosedFaturat";
export const BIZNESI_KEY = "biznesi";
export const LOKALI_KEY = "lokali";
export const VIDEOLOJAT_KEY = "videolojat";
export const FATURAT_KEY = "faturat";
export const CMIMORJA_KEY = "cmimorja"

//Fetch functions
const fetchBiznesiKonzola = async () => {
    let response = await agent.BiznesiKonzolat.listById(1).then(response => {
        return response;
    })
    console.log("fetchBiznesiKonzola was called.")
    return response;
}

const fetchNonClosedFaturat = async () => {
    let response = await agent.Faturat.listLokaliNonClosed(1).then(response => {
        return response;
    })
    console.log("fetchNonClosedFaturat was called.")
    return response
}

const fetchVideolojat = async () => {
    let response = await agent.VideoLojat.list().then(response => {
        return response;
    })
    console.log("videolojat was called")
    return response;
}

//Hooks
export const useBiznesiKonzolat = () => {
    return useQuery(BIZNESI_KONZOLA_KEY, fetchBiznesiKonzola);
}
export const useNonClosedFaturat = () => {
    return useQuery(NON_CLOSED_FATURAT, fetchNonClosedFaturat);
}
export const useVideolojat = () => {
    return useQuery(VIDEOLOJAT_KEY, fetchVideolojat);
}