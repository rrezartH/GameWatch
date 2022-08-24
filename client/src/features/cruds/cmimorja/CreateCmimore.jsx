import React, {useState, useContext} from 'react';
import { GWContext } from '../../../context/GWContext';
import '../../../styles/popup.scss';
import agent from '../../../api/agents';
import { FormInput, FormSelect } from '../../../components/form/input/FormInput';

const CreateCmimore = (props) => {

  const { bizneset } = useContext(GWContext);
  const {cmimorjaId, isForUpdate} = props;

  const [cmimorja, setCmimorja] = useState({
    nrLojtareve: 0,
    cmimi: 0,
    biznesiId: 0
  });
  
  const handleChange = (e) => {
    const name = e.target.name;
    const value = parseInt( e.target.value, 10);

    setCmimorja((prev) => {
      return { ...prev, [name]: value}
    });
  }

  const handleSubmit = (e) => {
    e.preventDefault()

    if(isForUpdate){
      agent.Cmimoret.update(cmimorjaId, cmimorja)
        .catch((error) => console.log(error))
    }
    else{
      console.log(cmimorja);
      agent.Cmimoret.create(cmimorja)
        .catch(function(error) {
          console.log(error.response.data)
        });
    }
  }

  return (
    <div className='popup'>
      <div className='popup-inner'>
        <h3>{isForUpdate ? "Update Cmimoren" : "Shto Cmimore"}</h3>
        <button className='close-btn' onClick={() => props.setShowCreate(!props.showCreate)}>x</button>
        <form onSubmit={handleSubmit} >
          <FormInput
            required={!isForUpdate} 
            label="Numri i Lojtareve" 
            type="text" 
            name="nrLojtareve" 
            placeholder="Numri i Lojtareve" 
            onChange={handleChange}
            />
          <FormInput
            required={!isForUpdate} 
            label="Cmimi" 
            type="text" 
            name="cmimi" 
            placeholder="Cmimi" 
            onChange={handleChange}
            />
          <FormSelect
            objects={bizneset}
            name="biznesiId"
            label="Biznesi"
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

export default CreateCmimore