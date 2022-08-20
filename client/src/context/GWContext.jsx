import React from 'react'
import { useEffect, useState, createContext } from 'react'
import agent from '../api/agents';

export const GWContext = createContext();

export const GWProvider = props => {

    const [bizneset, setBizneset] = useState([])

    useEffect(() => {
        agent.Bizneset.list().then(response => {
        setBizneset(response);
        })
    },[])

  return(
    <GWContext.Provider value={ {bizneset} }>
        {props.children}
    </GWContext.Provider>
  )
};