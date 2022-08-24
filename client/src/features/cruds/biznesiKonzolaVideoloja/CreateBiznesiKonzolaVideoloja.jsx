import React, {useState, useContext} from 'react';
import { GWContext } from '../../../context/GWContext';
import '../../../styles/popup.scss';
import agent from '../../../api/agents';
import { FormSelect } from '../../../components/form/input/FormInput';

const CreateBiznesiKonzolaVideoloja = (props) => {
  const {biznesiKonzolat, videoLojat} = useContext(GWContext);
  const {biznesiKonzolaVideolojaId, isForUpdate} = props;

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

    if(isForUpdate){
      agent.BizneziKonzolaVideolojat.update(biznesiKonzolaVideolojaId, biznesiKonzolaVideoloja)
        .catch((error) => console.log(error))
    }
    else{
      console.log(biznesiKonzolaVideoloja);
      agent.BizneziKonzolaVideolojat.create(biznesiKonzolaVideoloja)
        .catch(function(error) {
          console.log(error.response.data)
        });
    }
  }

  return (
    <div className='popup'>
      <div className='popup-inner'>
      <h3>{isForUpdate ? "Update BizKonVid" : "Shto BizKonVid"}</h3>
        <button className='close-btn' onClick={() => props.setShowCreate(!props.showCreate)}>x</button>
        <form onSubmit={handleSubmit} >
          <FormSelect
            objects={biznesiKonzolat}
            name="biznesiKonzola"
            label="Emri i Konzoles"
            onChange={handleChange}
            objectName={"emri"}
            required={!isForUpdate}
            />
          <FormSelect
            objects={videoLojat}
            name="videolojaId"
            label="Videoloja"
            onChange={handleChange}
            objectName={"emri"}
            required={!isForUpdate}
            />
          <button type='submit'>{isForUpdate ? "Update" : "Shto"}</button>
        </form>
      </div>
    </div>
  )
}

export default CreateBiznesiKonzolaVideoloja