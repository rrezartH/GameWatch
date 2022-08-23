import React, {useState, useContext} from 'react';
import { GWContext } from '../../../context/GWContext';
import '../../../styles/popup.scss';
import agent from '../../../api/agents';
import { FormSelectQytetet, FormInput, FormSelect } from '../../../components/form/input/FormInput';

const CreateKonzole = (props) => {

  const [konzola, setKonzola] = useState({
    modeli:""
  });
  
  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    setKonzola((prev) => {
      return { ...prev, [name]: value}
    });   
  }

  const handleSubmit = (e) => {
    e.preventDefault()
    console.log(konzola);
    agent.Konzolat.create(konzola)
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
            label="Modeli i Konzoles" 
            type="text" 
            name="modeli" 
            placeholder="Modeli i Konzoles" 
            onChange={handleChange}
            />
          <button type='submit'>Shto</button>
        </form>
      </div>
    </div>
  )
}

export default CreateKonzole