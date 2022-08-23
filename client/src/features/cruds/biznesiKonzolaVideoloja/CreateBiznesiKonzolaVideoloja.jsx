import React, {useState, useContext} from 'react';
import { GWContext } from '../../../context/GWContext';
import '../../../styles/popup.scss';
import agent from '../../../api/agents';
import { FormInput, FormSelect } from '../../../components/form/input/FormInput';

const CreateBiznesiKonzolaVideoloja = (props) => {
  const {biznesiKonzolat, videoLojat} = useContext(GWContext);

  const [biznesiKonzolaVideoloja, setBiznesiKonzolaVideoloja] = useState({
    biznesiKonzola: 0,
    videoLojaId: 0
  });
  
  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    
    if(name.toLowerCase().includes("id")) {
      let intValue = parseInt(value, 10);
      setBiznesiKonzolaVideoloja((prev) => {
        return { ...prev, [name]: intValue}
      });
    } 
    else {  
      setBiznesiKonzolaVideoloja((prev) => {
        return { ...prev, [name]: value}
      });
    }
  }

  const handleSubmit = (e) => {
    e.preventDefault()
    console.log(biznesiKonzolaVideoloja);
    agent.BizneziKonzolaVideolojat.create(biznesiKonzolaVideoloja)
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
          <FormSelect
            objects={biznesiKonzolat}
            name="biznesiKonzola"
            label="Emri i Konzoles"
            onChange={handleChange}
            objectName={"emri"}
            />
          <FormSelect
            objects={videoLojat}
            name="videolojaId"
            label="Videoloja"
            onChange={handleChange}
            objectName={"emri"}
            />
          <button type='submit'>Shto</button>
        </form>
      </div>
    </div>
  )
}

export default CreateBiznesiKonzolaVideoloja