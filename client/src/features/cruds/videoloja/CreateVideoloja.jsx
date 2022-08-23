import React, {useState} from 'react';
import { GWContext } from '../../../context/GWContext';
import '../../../styles/popup.scss';
import agent from '../../../api/agents';
import { FormSelectQytetet, FormInput, FormSelect } from '../../../components/form/input/FormInput';

const CreateVideoloja = (props) => {

  const [videoLoja, setVideoLojat] = useState({
    emri:""
  });
  
  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    setVideoLojat((prev) => {
      return { ...prev, [name]: value}
    });   
  }

  const handleSubmit = (e) => {
    e.preventDefault()
    console.log(videoLoja);
    agent.VideoLojat.create(videoLoja)
      .catch(function(error) {
        console.log(error.response.data)
      });
  }

  return (
    <div className='popup'>
      <div className='popup-inner'>
        <h3>Shto Videoloje</h3>
        <button className='close-btn' onClick={() => props.setShowCreate(!props.showCreate)}>x</button>
        <form onSubmit={handleSubmit} >
          <FormInput
            required={true} 
            label="Emri i Videolojes" 
            type="text" 
            name="emri" 
            placeholder="Emri i Videolojes" 
            onChange={handleChange}
            />
          <button type='submit'>Shto</button>
        </form>
      </div>
    </div>
  )
}

export default CreateVideoloja