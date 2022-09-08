import React, { useState } from 'react'
import agent from '../../../api/agents';
import { FormInput, FormSelect } from '../../../components/form/input/FormInput';
import { BIZNESI_KONZOLA_KEY, NON_CLOSED_FATURAT } from '../../../hooks/useBiznesiKonzola';
import { useMutation, useQueryClient } from 'react-query';

const AddKonzolaSession = (props) => {

   const { setShowFreeKonzola, showFreeKonzola, bizKonzolaId, videoLojat } = props

  const queryClient = useQueryClient();

   const [fatura, setFatura] = useState({
    mbarimiLojes: "",
    nrLojtareve: 0,
    oret: 0.0,
    biznesiKonzola: bizKonzolaId,
    videoLojaId: 0,
    lokaliId: 1, //hardcoded
    cmimiTotal: 0.0
  });
  
  const createFatura = (fatura) =>
    agent.Faturat.create(fatura).then(response => {
      console.log(response)
    }).catch(function(error) {
      console.log(error.response.data)
    });
  

  const { mutate } =  useMutation(createFatura, {
    onSuccess: () => {
      queryClient.invalidateQueries({BIZNESI_KONZOLA_KEY, NON_CLOSED_FATURAT});
    }
  })

  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    if(value !== ""){
    setFatura((prev) => {
      return { ...prev, [name]: value}
    })} else{
      setFatura((prev) => {
        return { ...prev, [name]: 0}
      })
    }
    //the solution above is to not send a null value to the post request
  }

  const handleSubmit = (e) => {
    e.preventDefault()
    mutate(fatura)
    setShowFreeKonzola(!showFreeKonzola);
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