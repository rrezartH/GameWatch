import React, { useState } from 'react'
import { useContext } from 'react';
import agent from '../../../api/agents';
import { FormInput, FormSelect, FormSelectQytetet } from '../../../components/form/input/FormInput';
import { GWContext } from '../../../context/GWContext';

const AddKonzolaSession = (props) => {

   const { setShowFreeKonzola, showFreeKonzola, bizKonzolaId } = props

   const { videoLojat } = useContext(GWContext);

   const [fatura, setFatura] = useState({
    mbarimiLojes: "",
    nrLojtareve: 0,
    oret: 0,
    biznesiKonzola: bizKonzolaId,
    videoLojaId: 0,
    lokaliId: 1, //hardcoded
    cmimiTotal: 0
  });
  
  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    setFatura((prev) => {
      return { ...prev, [name]: value}
    })
  }

  const handleSubmit = (e) => {
    e.preventDefault()
    console.log(fatura)

    agent.Faturat.create(fatura).catch(function(error) {
        console.log(error.response.data)
      });

    // if(isForUpdate){
    //   agent.Bizneset.update(biznesiId, biznesi)
    //     .catch((error) => console.log(error))
    // }
    // else{
    //   console.log(biznesi);
    //   agent.Bizneset.create(biznesi)
    //     .catch(function(error) {
    //       console.log(error.response.data)
    //     });
    // }
  }

  return (
    <div className='popup'>
      <div className='popup-inner-konzola'>
        <button className='close-btn-konzola' onClick={() => setShowFreeKonzola(!showFreeKonzola)}>x</button>
        <form onSubmit={handleSubmit} className="form" >
          <label htmlFor="nrLojtareve"> Numri i Lojtareve</label>
          <select
            onChange={handleChange}
            name="nrLojtareve"
            required
            >
            <option value="">Zgjedh</option>
            <option value="1">1</option>
            <option value="2">2</option>
            <option value="3">3</option>
            <option value="4">4</option>
          </select>
          <FormInput 
            //required={!isForUpdate} 
            label="Sa ore?" 
            type="number" 
            name="oret" 
            placeholder="Sa ore?" 
            onChange={handleChange}
            />
          <FormSelect 
            label="Videoloja"
            name="videoLojaId"
            onChange={handleChange}
            objects={videoLojat}
            objectName="emri"
            />
          <FormInput 
            //required={!isForUpdate} 
            label="Cmimi Total" 
            type="number" 
            name="cmimiTotal" 
            placeholder="Cmimi Total" 
            onChange={handleChange}
            />
          <button type='submit'>Shto</button>
        </form>

      </div>
    </div>
  )
}

export default AddKonzolaSession