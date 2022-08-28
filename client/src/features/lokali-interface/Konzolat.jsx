import React, { useContext, useState } from 'react';
import { GWContext } from '../../context/GWContext';
import SelectedKonzola from './SelectedKonzola/SelectedKonzola';
import './_lokali-styles.scss';
import RedStatusIcon from '../../img/popup-konzola-assets/red-status.svg';
import GreenStatusIcon from '../../img/popup-konzola-assets/green-status.svg';
import GamePlayedIcon from '../../img/popup-konzola-assets/game-played.svg';
import TimeFinishIcon from '../../img/popup-konzola-assets/time-finish.svg';

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
                            <div className="konzola-playstation-title">
                                <h1>{konzola.emri}</h1>
                            </div>
                            <div className="konzola-playstation-body">
                                <div className="konzola-playstation-description">
                                    <p className="konzola-modeli">{konzola.konzola.modeli}</p>
                                    {konzola.statusi ? 
                                        <div className='img-text-group'> 
                                            <img src={GamePlayedIcon} alt="game-played-icon" />     
                                            <p>{lokaliFaturat.find(fatura => fatura.biznesiKonzola === konzola.id)?.videoLoja.emri}</p>
                                        </div> : null}
                                    {konzola.statusi ? 
                                        <div className='img-text-group'> 
                                            <img src={TimeFinishIcon} alt="time-finish-icon" />  
                                            <p>Mbaron: {convertToTime(lokaliFaturat.find(fatura => fatura.biznesiKonzola === konzola.id)?.mbarimiLojes)}</p></div>
                                            : null}
                                </div>
                                <img src={konzola.statusi ? RedStatusIcon : GreenStatusIcon} alt="status" />
                            </div>
                            <button className='expand' onClick={() => {setShowKonzola(!showKonzola); setBizKonzolaId(konzola.id)}}>Zmadho</button>
                        </div>
                )))}
            </div>
        </div>
        { showKonzola ? <SelectedKonzola 
                            bizKonzola={bizKonzolat.find(b => b.id === bizKonzolaId)}
                            fatura={lokaliFaturat.find(fatura => fatura.biznesiKonzola === bizKonzolaId)}
                            setShowKonzola={setShowKonzola}
                            showKonzola={showKonzola}
                            /> : ""}
    </>
  ) 
}

export default Konzolat