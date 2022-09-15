import { useQuery } from "react-query";
import agent from "../api/agents"

//Query keys
export const BIZNESI_KONZOLA_KEY = "biznesiKonzola";
export const NON_CLOSED_FATURAT = "nonClosedFaturat";
export const BIZNESI_KEY = "biznesi";
export const LOKALI_KEY = "lokali";
export const VIDEOLOJAT_KEY = "videolojat";
export const FATURAT_KEY = "faturat";
export const CMIMORJA_KEY = "cmimorja";
export const FATURAT_E_LOKALIT_KEY = "lokaliFaturat";

//static id



//Fetch functions
const fetchBiznesiKonzola = async () => {
    console.log("fetchBiznesiKonzola was called.")
    return await agent.BiznesiKonzolat.listById(1).then(response => {
        return response;
    });
}
const fetchNonClosedFaturat = async (id) => {
    console.log("fetchNonClosedFaturat was called.")
    return await agent.Faturat.listLokaliNonClosed(id).then(response => {
        return response;
    })
}
const fetchVideolojat = async () => {
    console.log("videolojat was called")
    return await agent.VideoLojat.list().then(response => {
        return response;
    });
}
const fetchFaturatELokalit = async (id, pageNumber) => {
    console.log("Faturat e lokalit called.");
    return await agent.Faturat.listFaturatELokalit(id, pageNumber).then(response => {
        return response;
    })
}

//Hooks
export const useBiznesiKonzolat = () => {
    return useQuery(BIZNESI_KONZOLA_KEY, fetchBiznesiKonzola);
}
export const useNonClosedFaturat = (id) => {
    return useQuery(NON_CLOSED_FATURAT, () => fetchNonClosedFaturat(id));
}
export const useVideolojat = () => {
    return useQuery(VIDEOLOJAT_KEY, fetchVideolojat);
}
export const useFaturatELokalit = (id, pageNumber) => {
    return useQuery([FATURAT_E_LOKALIT_KEY, pageNumber], () => fetchFaturatELokalit(id, pageNumber));
}
