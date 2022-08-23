import React, {useState, useContext} from 'react';
import { GWContext } from '../../../context/GWContext';
import '../../../styles/popup.scss';
import agent from '../../../api/agents';
import { FormInput, FormSelect } from '../../../components/form/input/FormInput';

const CreateBiznesiKonzola = (props) => {
  const {lokalet, konzolat} = useContext(GWContext);

  const [biznesiKonzola, setBiznesiKonzola] = useState({
    emri: "",
    konzolaId: 0,
    lokaliId: 0
  });
  
  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    
    if(name.toLowerCase().includes("id")) {
      let intValue = parseInt(value, 10);
      setBiznesiKonzola((prev) => {
        return { ...prev, [name]: intValue}
      });
    } 
    else {  
      setBiznesiKonzola((prev) => {
        return { ...prev, [name]: value}
      });
    }
  }

  const handleSubmit = (e) => {
    e.preventDefault()
    console.log(biznesiKonzola);
    agent.BiznesiKonzolat.create(biznesiKonzola)
      .catch(function(error) {
        console.log(error.response.data)
      });
  }

  return (
    <div className='popup'>
      <div className='popup-inner'>
        <h3>Shto Konzole</h3>
        <button className='close-btn' onClick={() => props.setShowCreate(!props.showCreate)}>x</button>
        <form onSubmit={handleSubmit} >
          <FormInput
            required={true} 
            label="Emri i Konzoles" 
            type="text" 
            name="emri" 
            placeholder="Emri i Konzoles" 
            onChange={handleChange}
            />
          <FormSelect
            objects={konzolat}
            name="konzolaId"
            label="Konzola"
            onChange={handleChange}
            objectName={"modeli"}
            />
           <FormSelect
            objects={lokalet}
            name="lokaliId"
            label="Lokali"
            onChange={handleChange}
            objectName={"emri"}
            />
          <button type='submit'>Shto</button>
        </form>
      </div>
    </div>
  )
}

export default CreateBiznesiKonzola