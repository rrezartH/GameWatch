import React, { useEffect, useState } from 'react';
import agent from '../../api/agents';
import SelectedKonzola from './SelectedKonzola/SelectedKonzola';
import './_lokali-styles.scss';

const Konzolat = () => {

    const[bK, setBK] = useState([]);
    const[showKonzola, setShowKonzola] = useState(false);

    useEffect(() => {
    agent.BiznesiKonzolat.listById(1).then(response => {
        setBK(response)
    })
    console.log(bK);
    },[])

  

  return (
    <>
        <div className="konzola">
            <div className="konzola-sidebar">
                <ul>
                {React.Children.toArray(
                    bK.map(konzola => (
                            <li>{konzola.konzola.modeli}</li>
                )))}
                </ul>
            </div>
            <div className="konzola-main">
                {React.Children.toArray(
                    bK.map(konzola => (
                        <div className="konzola-playstation">
                            <h1>{konzola.konzola.modeli}</h1>
                            <p>Loja: FIFA22</p>
                            <p>Mbaron: 15:35</p>
                            <p>Statusi: {konzola.statusi ? "E zene" : "E lire"}</p>
                            <button className='expand' onClick={() => setShowKonzola(!showKonzola)}>Zmadho</button>
                        </div>
                )))}
            </div>
        </div>
        { showKonzola ? <SelectedKonzola /> : ""}
    </>
  )
}

export default Konzolat