import React from 'react'

const SelectedKonzola = (props) => {
  return (
    <div className='popup'>
      <div className='popup-inner'>
        <button className='close-btn' onClick={() => props.setShowKonzola(!props.showKonzola)}>x</button>
        {console.log(props.bizKonzola)}
        
      </div>
    </div>
  )
}

export default SelectedKonzola