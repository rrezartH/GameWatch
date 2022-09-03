import React from 'react'
import GamePlayedIcon from '../../../img/popup-konzola-assets/game-played.svg';
import PriceIcon from '../../../img/popup-konzola-assets/price.svg';
import TimeFinishIcon from '../../../img/popup-konzola-assets/time-finish.svg';
import TimeStartIcon from '../../../img/popup-konzola-assets/time-start.svg';
import TimeIcon from '../../../img/popup-konzola-assets/time.svg';
import PlayersIcon from '../../../img/popup-konzola-assets/players.svg'
import agent from '../../../api/agents';

const SelectedKonzola = (props) => {

  const{ bizKonzola, fatura, setShowTakenKonzola, showTakenKonzola } = props

  function handleFinalize(id) {
    agent.Faturat.finalize(id).catch(function(error) {
      console.log(error.response.data)
    });
    console.log("Fatura u finalizua!");
  }

  return (
    <div className='popup'>
      <div className='popup-inner-konzola'>
        <button className='close-btn-konzola' onClick={() => setShowTakenKonzola(!showTakenKonzola)}>x</button>
        <div className="selected-konzola">
          <div className="selected-konzola-title">
            <h3>{bizKonzola.emri}</h3>
            <p>ID #{fatura?.id}</p>
          </div>
          <div className="selected-konzola-details">
            <div className="selected-konzola-details-left">
              <div className='selected-konzola-details-element'> <img src={GamePlayedIcon} alt="game-played-icon" />  <p>{fatura?.videoLoja.emri}</p></div>
              <div className='selected-konzola-details-element'> <img src={TimeStartIcon} alt="time-start-icon" /> <p>{fatura?.fillimiLojes}</p> </div>
              <div className='selected-konzola-details-element'> <img src={TimeFinishIcon} alt="time-finish-icon" /> <p>{fatura?.mbarimiLojes !== "" ? fatura?.mbarimiLojes : "Pacaktuar"}</p> </div>
            </div>            
            <div className="selected-konzola-details-right">
              <div className='selected-konzola-details-element'> <img src={PlayersIcon} alt="players-icon" /><p>{fatura?.nrLojtareve} Lojtarë</p> </div>
              <div className='selected-konzola-details-element'> <img src={TimeIcon} alt="time-icon" /><p>{fatura?.oret} Orë</p> </div>
              <div className='selected-konzola-details-element'> <img src={PriceIcon} alt="price-icon" /><p>{fatura?.cmimiTotal}€</p> </div>
            </div>
          </div>
        </div>
        <div className="konzola-buttons">
          <button className='perfundo-button' onClick={() => handleFinalize(fatura?.id)}>Finalizo</button>
          <button className='perditeso-button'>Perditeso</button>
        </div>
      </div>
    </div>
  )
}

export default SelectedKonzola