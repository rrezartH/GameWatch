import React from 'react'
import { useEffect, useState, createContext } from 'react'
import agent from '../api/agents';
import { useBiznesiKonzolat } from '../hooks/useBiznesiKonzola';

export const GWContext = createContext();

export const GWProvider = props => {

    const [bizneset, setBizneset] = useState([])
    const [lokalet, setLokalet] = useState([])
    const [konzolat, setKonzolat] = useState([])
    const [biznesiKonzolat, setBiznesiKonzolat] = useState([])
    const [bizneziKonzolaVideolojat, setBizneziKonzolaVideolojat] = useState([])
    const [cmimoret, setCmimoret] = useState([])
    const [faturat, setFaturat] = useState([])
    //const [users, setUsers] = useState([])
    const [videoLojat, setVideoLojat] = useState([])

    //user
    //const[bizKonzolat, setBizKonzolat] = useState([]);
    const[lokaliFaturat, setLokaliFaturat] = useState([]);

    //const { data: bizKonzolat } = useBiznesiKonzolat();

    function fetchDbAsAdmin() {
      agent.Bizneset.list().then(response => {
        setBizneset(response);
        })
        agent.Lokalet.list().then(response => {
          setLokalet(response)
        })
        agent.Konzolat.list().then(response => {
          setKonzolat(response)
        })
         agent.BiznesiKonzolat.list().then(response => {
           setBiznesiKonzolat(response)
         })
        agent.BizneziKonzolaVideolojat.list().then(response => {
          setBizneziKonzolaVideolojat(response)
        })
        agent.Cmimoret.list().then(response => {
          setCmimoret(response)
        })
        agent.Faturat.list().then(response => {
          setFaturat(response)
        })
        agent.VideoLojat.list().then(response => {
          setVideoLojat(response)
        })
    }

    function fetchDbAsUser() {
    //   agent.BiznesiKonzolat.listById(1).then(response => {
    //     setBizKonzolat(response)
    // })
      agent.Faturat.listLokaliNonClosed(1).then(response => {
        setLokaliFaturat(response)
      })
    }

    useEffect(() => {
        fetchDbAsAdmin()
        fetchDbAsUser()
    },[])

  return(
    <GWContext.Provider value={{
      bizneset,
      lokalet,
      konzolat,
      biznesiKonzolat,
      bizneziKonzolaVideolojat,
      cmimoret,
      faturat,
      videoLojat,
      lokaliFaturat
      } }>
        {props.children}
    </GWContext.Provider>
  )
};