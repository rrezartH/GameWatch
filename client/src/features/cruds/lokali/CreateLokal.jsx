import React, {useState, useContext} from 'react';
import { GWContext } from '../../../context/GWContext';
import '../../../styles/popup.scss';
import agent from '../../../api/agents';
import { FormSelectQytetet, FormInput, FormSelect } from '../../../components/form/input/FormInput';

const CreateLokal = (props) => {

  const { bizneset } = useContext(GWContext);

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
    console.log(lokali);
    agent.Lokalet.create(lokali)
      .catch(function(error) {
        console.log(error.response.data)
      });
  }

  return (
    <div className='popup'>
      <div className='popup-inner'>
        <h3>Shto Lokal</h3>
        <button className='close-btn' onClick={() => props.setShowCreate(!props.showCreate)}>x</button>
        <form onSubmit={handleSubmit} >
          <FormInput
            required={true} 
            label="Emri i Lokali" 
            type="text" 
            name="emri" 
            placeholder="Emri i Lokalit" 
            onChange={handleChange}
            />
          <FormInput 
            required={true} 
            label="Numri i Telefonit" 
            type="number" 
            name="nrTel" 
            placeholder="Numri i telefonit" 
            onChange={handleChange}
            />
          <FormSelectQytetet 
            onChange={handleChange} 
            name="qyteti" 
            defaultValue="Qyteti" 
            />
          <FormInput 
            required={true} 
            label="Adresa" 
            type="text" 
            name="adresa" 
            placeholder="Adresa" 
            onChange={handleChange}
            />
          <FormSelect
            objects={bizneset}
            name="biznesiId"
            label="Biznesi"
            onChange={handleChange}
            objectName={"emri"}
            />
          <button type='submit'>Shto</button>
        </form>
      </div>
    </div>
  )
}

export default CreateLokal