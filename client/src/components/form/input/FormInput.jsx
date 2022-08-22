import React from 'react';
import './form-input.scss';

const FormInput = (props) => {
  return (
    <div className='form-input'>
        {/* <label htmlFor=""> Username</label> */}
        <input
            name={props.name}
            placeholder={props.placeholder} 
            type={props.type}
            onChange={props.onChange}
             />
    </div>
  )
}

export default FormInput