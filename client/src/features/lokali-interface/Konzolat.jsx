import React, { useState } from 'react';
import SelectedKonzola from './SelectedKonzola/SelectedKonzola';
import './_lokali-styles.scss';
import RedStatusIcon from '../../img/popup-konzola-assets/red-status.svg';
import GreenStatusIcon from '../../img/popup-konzola-assets/green-status.svg';
import GamePlayedIcon from '../../img/popup-konzola-assets/game-played.svg';
import TimeFinishIcon from '../../img/popup-konzola-assets/time-finish.svg';
import AddKonzolaSession from './SelectedKonzola/AddKonzolaSession';
import CreateBiznesiKonzola from '../cruds/biznesiKonzola/CreateBiznesiKonzola';
import { useBiznesiKonzolat, useNonClosedFaturat, useVideolojat } from '../../hooks/useBiznesiKonzola';
import ScaleLoader from "react-spinners/ScaleLoader";


const Konzolat = () => {
    const[showTakenKonzola, setShowTakenKonzola] = useState(false);
    const[showFreeKonzola, setShowFreeKonzola] = useState(false);
    const[bizKonzolaId, setBizKonzolaId] = useState();
    const[showCreate, setShowCreate] = useState(false);

    //TODO: get the lokaliID from authentication
    const lokaliId = 1;

    const { isLoading: isVideolojatLoading, data: videoLojat } = useVideolojat();
    const { isLoading: isBizKonzolatLoading, data: bizKonzolat} = useBiznesiKonzolat();
    const { isLoading: isNonClosedFaturatLoading, data: lokaliFaturat} = useNonClosedFaturat(lokaliId);
    function convertToTime(dateTime) {
        let date = new Date(dateTime);
        return date.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit', hour12: false });
    }

  if(isBizKonzolatLoading || isNonClosedFaturatLoading || isVideolojatLoading){
    return <ScaleLoader
                size={150}
                color={"#4bc3b5"}
                loading={isBizKonzolatLoading}
                speedMultiplier={1.5}
            />
  }

  const handleExpand = (konzolaId, konzolaStatusi) => {
    setBizKonzolaId(konzolaId)
    if(konzolaStatusi){
            setShowTakenKonzola(!showTakenKonzola)
        } else {
            setShowFreeKonzola(!showFreeKonzola);
        }
  }

  return (
    <>
        <div className="konzola">
            <div className="konzola-sidebar">
                <div className="konzola-sidebar-show">
                    {React.Children.toArray(
                        bizKonzolat?.map(konzola => (
                            <button onClick={() => handleExpand(konzola.id, konzola.statusi)}>{konzola?.emri }</button>
                    )))}
                </div>
                <button 
                    className='konzola-sidebar-add'
                    onClick={() => setShowCreate(!showCreate)}>
                    Shto Konzole
                </button>
            </div>    
                
            <div className="konzola-main">
                {React.Children.toArray(
                    bizKonzolat?.map(konzola => (
                        <div className="konzola-playstation">
                            <div className="konzola-playstation-title">
                                <h1>{konzola.emri}</h1>
                            </div>
                            <div className="konzola-playstation-body">
                                <div className="konzola-playstation-description">
                                    <p className="konzola-modeli">{konzola?.konzola?.modeli}</p>
                                    {konzola.statusi ? 
                                        <div className='img-text-group'> 
                                            <img src={GamePlayedIcon} alt="game-played-icon" />     
                                            <p>{lokaliFaturat.find(fatura => fatura.biznesiKonzola === konzola.id)?.videoLoja.emri}</p>
                                        </div> : null}
                                    {konzola.statusi && konzola.oret ? 
                                        <div className='img-text-group'> 
                                            <img src={TimeFinishIcon} alt="time-finish-icon" />  
                                            <p>{convertToTime(lokaliFaturat.find(fatura => fatura.biznesiKonzola === konzola.id)?.mbarimiLojes)}</p></div>
                                            : null}
                                </div>
                                <img src={konzola.statusi ? RedStatusIcon : GreenStatusIcon} alt="status" />
                            </div>
                            <button className='expand' onClick={() => handleExpand(konzola.id, konzola.statusi)}>Zmadho</button>
                        </div>
                )))}
            </div>
        </div>
        { showTakenKonzola ? <SelectedKonzola 
                            bizKonzola={bizKonzolat.find(b => b.id === bizKonzolaId)}
                            fatura={lokaliFaturat.find(fatura => fatura.biznesiKonzola === bizKonzolaId)}
                            setShowTakenKonzola={setShowTakenKonzola}
                            showTakenKonzola={showTakenKonzola}
                            /> : ""}
        { showFreeKonzola ? <AddKonzolaSession 
                            setShowFreeKonzola={setShowFreeKonzola}
                            showFreeKonzola={showFreeKonzola}
                            bizKonzolaId={bizKonzolaId}
                            videoLojat={videoLojat}
                                /> : ""}
        {showCreate ? <CreateBiznesiKonzola 
                      showCreate={showCreate} 
                      setShowCreate={setShowCreate} 
                      biznesiKonzolaId={bizKonzolaId}
                      lokaliId={lokaliId}
                      /> : null}
    </>
  ) 
}

export default Konzolat