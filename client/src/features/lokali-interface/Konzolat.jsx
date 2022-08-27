import React, { useContext, useState } from 'react';
import { GWContext } from '../../context/GWContext';
import SelectedKonzola from './SelectedKonzola/SelectedKonzola';
import './_lokali-styles.scss';

const Konzolat = () => {
    const[showKonzola, setShowKonzola] = useState(false);

    const{ bizKonzolat, lokaliFaturat} = useContext(GWContext);

  return (
    <>
        <div className="konzola">
            <div className="konzola-sidebar">
                <ul>
                {React.Children.toArray(
                    bizKonzolat.map(konzola => (
                        <li>{konzola.konzola.modeli}</li>
                )))}
                </ul>
            </div>
            <div className="konzola-main">
                {React.Children.toArray(
                    bizKonzolat.map(konzola => (
                        <div className="konzola-playstation">
                            <h1>{konzola.emri}</h1>
                            {konzola.statusi ? <p>Loja:{lokaliFaturat.find(fatura => fatura.biznesiKonzola === konzola.id)?.id}</p> : null}
                            {konzola.statusi ? <p>Mbaron:</p> : null}
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