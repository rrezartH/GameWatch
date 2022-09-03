import React, { useState } from 'react'
import agent from '../../../api/agents'
import { FormInput } from '../../../components/form/input/FormInput'

const UpdateFatura = (props) => {

   const { faturaId, setShowUpdateFatura, showUpdateFatura } = props 
   const [fatura, setFatura] = useState({
    oret: 0,
    cmimiTotal: 0
   });

   const handleChange = (e) => {
    const name = e.target.name;
    const value = parseInt(e.target.value, 10);

    setFatura((prev) => {
      return { ...prev, [name]: value}
    })
  }

   const handleSubmit = (e) => {
    e.preventDefault()
    console.log(fatura)
    agent.Faturat.update(faturaId, fatura)
        .catch((error) => console.log(error));

   }

    return (
        <div className='popup'>
            <div className='popup-inner-konzola'>
                <button className='close-btn-konzola' onClick={() => setShowUpdateFatura(!showUpdateFatura)}>x</button>
                <div className="update-fatura">  
                    <h3>Perditeso Faturen</h3>
                    <form onSubmit={handleSubmit}>
                        <div className='update-fatura-inputs'>
                            <FormInput 
                                label="Oret"
                                type="number"
                                name="oret"
                                placeholder="Oret"
                                onChange={handleChange}
                            />
                            <FormInput 
                                label="Cmimi Total"
                                type="number"
                                name="cmimiTotal"
                                placeholder="Cmimi Total"
                                onChange={handleChange}
                            />
                        </div>
                        <button type='submit'>Perditeso</button>
                    </form>
                </div>
            </div>
        </div>
  )
}

export default UpdateFatura