import React, {useState} from 'react';
import '../../../styles/popup.scss';
import agent from '../../../api/agents';
import { FormInput } from '../../../components/form/input/FormInput';

const CreateKonzole = (props) => {

  const {konzolaId, isForUpdate} = props;

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

    if(isForUpdate){
      agent.Konzolat.update(konzolaId, konzola)
        .catch((error) => console.log(error))
    }
    else{
      console.log(konzola);
      agent.Konzolat.create(konzola)
        .catch(function(error) {
          console.log(error.response.data)
        });
    }
  }

  return (
    <div className='popup'>
      <div className='popup-inner'>
        <h3>{isForUpdate ? "Update Konzolen" : "Shto Konzole"}</h3>
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
          <button type='submit'>{isForUpdate ? "Update" : "Shto"}</button>
        </form>
      </div>
    </div>
  )
}

export default CreateKonzole