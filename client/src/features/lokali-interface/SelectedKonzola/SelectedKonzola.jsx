import React, { useState } from 'react'
import GamePlayedIcon from '../../../img/popup-konzola-assets/game-played.svg';
import PriceIcon from '../../../img/popup-konzola-assets/price.svg';
import TimeFinishIcon from '../../../img/popup-konzola-assets/time-finish.svg';
import TimeStartIcon from '../../../img/popup-konzola-assets/time-start.svg';
import TimeIcon from '../../../img/popup-konzola-assets/time.svg';
import PlayersIcon from '../../../img/popup-konzola-assets/players.svg'
import agent from '../../../api/agents';
import UpdateFatura from './UpdateFatura';
import { useMutation, useQueryClient } from 'react-query';
import { BIZNESI_KONZOLA_KEY } from '../../../hooks/useBiznesiKonzola';

const SelectedKonzola = (props) => {

  const{ bizKonzola, fatura, setShowTakenKonzola, showTakenKonzola } = props

  const[localFatura, setLocalFatura] = useState(fatura)
  const[showUpdateFatura, setShowUpdateFatura] = useState(false);

  const queryClient = useQueryClient();

  const finalizeFatura = (id) => agent.Faturat.finalize(id).catch(function(error) {
    console.log(error.response.data)
  });

  const { mutate } =  useMutation(finalizeFatura, {
    onSuccess: () => {
      queryClient.invalidateQueries(BIZNESI_KONZOLA_KEY);
    }
  })

  function handleFinalize(id) {
    mutate(id);
    console.log("Fatura u finalizua!");
    setShowTakenKonzola(!showTakenKonzola);
  }

  function handlePreview(id) {
    agent.Faturat.preview(id)
      .then(response => {
        setLocalFatura((prev) => {
          return {
            ...prev, 
            cmimiTotal: response.cmimiTotal, 
            oret: response.oret, 
            mbarimiLojes: response.mbarimiLojes}
        });
      }).catch(function(error) {
        console.log(error.response.data)
      });
  }

  return (
    <>
      <div className='popup'>
        <div className='popup-inner-konzola'>
          <button className='close-btn-konzola' onClick={() => setShowTakenKonzola(!showTakenKonzola)}>x</button>
          <div className="selected-konzola">
            <div className="selected-konzola-title">
              <h3>{bizKonzola.emri}</h3>
              <p>ID #{localFatura?.id}</p>
            </div>
            <div className="selected-konzola-details">
              <div className="selected-konzola-details-left">
                <div className='selected-konzola-details-element'> <img src={GamePlayedIcon} alt="game-played-icon" />  <p>{localFatura?.videoLoja.emri}</p></div>
                <div className='selected-konzola-details-element'> <img src={TimeStartIcon} alt="time-start-icon" /> <p>{localFatura?.fillimiLojes}</p> </div>
                <div className='selected-konzola-details-element'> <img src={TimeFinishIcon} alt="time-finish-icon" /> <p>{localFatura?.mbarimiLojes !== "" ? localFatura?.mbarimiLojes : "Pacaktuar"}</p> </div>
              </div>            
              <div className="selected-konzola-details-right">
                <div className='selected-konzola-details-element'> <img src={PlayersIcon} alt="players-icon" /><p>{localFatura?.nrLojtareve} Lojtarë</p> </div>
                <div className='selected-konzola-details-element'> <img src={TimeIcon} alt="time-icon" /><p>{localFatura?.oret} Orë</p> </div>
                <div className='selected-konzola-details-element'> <img src={PriceIcon} alt="price-icon" /><p>{localFatura?.cmimiTotal}€</p> </div>
              </div>
            </div>
          </div>
          <div className="konzola-buttons">
            <button className='finalizo-button' onClick={() => handleFinalize(localFatura?.id)}>Finalizo</button>
            {fatura.cmimiTotal !== 0 ? 
              <button className='perditeso-button' onClick={() => setShowUpdateFatura(!showUpdateFatura)}>Perditeso</button> 
            :
              <button onClick={() => handlePreview(fatura.id)}>Preview</button>
            }
          </div>
        </div>
      </div>
      {showUpdateFatura ? <UpdateFatura 
                            faturaId={fatura.id}
                            setShowUpdateFatura={setShowUpdateFatura} 
                            showUpdateFatura={showUpdateFatura}
                            /> : ""}
    </>
  )
}

export default SelectedKonzola