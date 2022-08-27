import React, { useContext, useState } from 'react';
import { GWContext } from '../../context/GWContext';
import SelectedKonzola from './SelectedKonzola/SelectedKonzola';
import './_lokali-styles.scss';

const Konzolat = () => {
    const[showKonzola, setShowKonzola] = useState(false);
    const[bizKonzolaId, setBizKonzolaId] = useState();

    const{ bizKonzolat, lokaliFaturat} = useContext(GWContext);

    function convertToTime(dateTime) {
        let date = new Date(dateTime);
        return date.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit', hour12: false });
    }

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
                            {konzola.statusi ? 
                            <p>Loja: {lokaliFaturat.find(fatura => fatura.biznesiKonzola === konzola.id)?.videoLoja.emri}</p> : null}
                            {konzola.statusi ? <p>Mbaron: {convertToTime(lokaliFaturat.find(fatura => fatura.biznesiKonzola === konzola.id)?.mbarimiLojes)}</p> : null}
                            <p>Statusi: {konzola.statusi ? "E zene" : "E lire"}</p>
                            <button className='expand' onClick={() => {setShowKonzola(!showKonzola); setBizKonzolaId(konzola.id)}}>Zmadho</button>
                        </div>
                )))}
            </div>
        </div>
        { showKonzola ? <SelectedKonzola 
                            bizKonzola={bizKonzolat.find(b => b.id == bizKonzolaId)}
                            fatura={lokaliFaturat.find(fatura => fatura.biznesiKonzola === bizKonzolaId)}
                            setShowKonzola={setShowKonzola}
                            showKonzola={showKonzola}
                            /> : ""}
    </>
  ) 
}

export default Konzolat