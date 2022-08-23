import React, {useState} from 'react';
import '../../../styles/popup.scss';
import agent from '../../../api/agents';
import { FormSelectQytetet, FormInput } from '../../../components/form/input/FormInput';

const CreateBiznes = (props) => {

  const [biznesi, setBiznesi] = useState({
    profilePicture: "",
    emri:"",
    email:"",
    nrTel:"",
    qyteti:"",
    adresa: ""
  });
  
  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    setBiznesi((prev) => {
      return { ...prev, [name]: value}
    })
  }

  const handleSubmit = (e) => {
    e.preventDefault()
    console.log(biznesi);
    agent.Bizneset.create(biznesi)
      .catch(function(error) {
        console.log(error.response.data)
      });
  }

  return (
    <div className='popup'>
      <div className='popup-inner'>
        <h3>Shto Biznes</h3>
        <button className='close-btn' onClick={() => props.setShowCreate(!props.showCreate)}>x</button>
        <form onSubmit={handleSubmit} >
          <FormInput 
            required={true} 
            label="Emri i Biznesit" 
            type="text" 
            name="emri" 
            placeholder="Emri i Biznesit" 
            onChange={handleChange}
            />
          <FormInput 
            required={true} 
            label="Email" 
            type="email" 
            name="email" 
            placeholder="Email" 
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
          <button type='submit'>Shto</button>
        </form>
      </div>
    </div>
  )
}

export default CreateBiznes