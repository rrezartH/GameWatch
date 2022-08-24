import React, {useState, useContext} from 'react';
import { GWContext } from '../../../context/GWContext';
import '../../../styles/popup.scss';
import agent from '../../../api/agents';
import { FormSelectQytetet, FormInput, FormSelect } from '../../../components/form/input/FormInput';

const CreateLokal = (props) => {

  const { bizneset } = useContext(GWContext);
  const {lokaliId, isForUpdate} = props;

  const [lokali, setLokali] = useState({
    emri:"",
    nrTel:"",
    qyteti:"",
    adresa: "",
    biznesiId: 0
  });
  
  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;

    if(name.toLowerCase().includes("id")) {
      let intValue = parseInt(value, 10);
      setLokali((prev) => {
        return { ...prev, [name]: intValue}
      });
    } 
    else {  
      setLokali((prev) => {
        return { ...prev, [name]: value}
      });
    }    
  }

  const handleSubmit = (e) => {
    e.preventDefault()

    if(isForUpdate){
      agent.Lokalet.update(lokaliId, lokali)
        .catch((error) => console.log(error))
    }
    else{
      console.log(lokali);
      agent.Lokalet.create(lokali)
        .catch(function(error) {
          console.log(error.response.data)
        });
    }
  }

  return (
    <div className='popup'>
      <div className='popup-inner'>
        <h3>{isForUpdate ? "Update Lokalin" : "Shto Lokal"}</h3>
        <button className='close-btn' onClick={() => props.setShowCreate(!props.showCreate)}>x</button>
        <form onSubmit={handleSubmit} >
          <FormInput
            required={!isForUpdate} 
            label="Emri i Lokali" 
            type="text" 
            name="emri" 
            placeholder="Emri i Lokalit" 
            onChange={handleChange}
            />
          <FormInput 
            required={!isForUpdate} 
            label="Numri i Telefonit" 
            type="number" 
            name="nrTel" 
            placeholder="Numri i telefonit" 
            onChange={handleChange}
            />
          <FormSelectQytetet 
            required={!isForUpdate}
            onChange={handleChange} 
            name="qyteti" 
            defaultValue="Qyteti" 
            />
          <FormInput 
            required={!isForUpdate} 
            label="Adresa" 
            type="text" 
            name="adresa" 
            placeholder="Adresa" 
            onChange={handleChange}
            />
          <FormSelect
              required={!isForUpdate} 
            objects={bizneset}
            name="biznesiId"
            label="Biznesi"
            onChange={handleChange}
            objectName={"emri"}
            />
          <button type='submit'>{isForUpdate ? "Update" : "Shto"}</button>
        </form>
      </div>
    </div>
  )
}

export default CreateLokal