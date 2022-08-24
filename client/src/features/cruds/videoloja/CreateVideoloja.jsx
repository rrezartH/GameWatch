import React, {useState} from 'react';
import '../../../styles/popup.scss';
import agent from '../../../api/agents';
import { FormInput } from '../../../components/form/input/FormInput';

const CreateVideoloja = (props) => {

  const {videoLojaId, isForUpdate} = props;

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

    if(isForUpdate){
      agent.VideoLojat.update(videoLojaId, videoLoja)
        .catch((error) => console.log(error))
    }
    else{
      console.log(videoLoja);
      agent.VideoLojat.create(videoLoja)
        .catch(function(error) {
          console.log(error.response.data)
        });
    }
  }


  return (
    <div className='popup'>
      <div className='popup-inner'>
        <h3>{isForUpdate ? "Update Videolojen" : "Shto Videolojen"}</h3>
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
          <button type='submit'>{isForUpdate ? "Update" : "Shto"}</button>
        </form>
      </div>
    </div>
  )
}

export default CreateVideoloja