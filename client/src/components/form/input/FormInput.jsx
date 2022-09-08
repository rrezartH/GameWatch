import React from 'react';
import './form-input.scss';
import { Children } from 'react';
import { qytetet } from '../../../api/localAPI';

export const FormInput = (props) => {

  return (
    <div className='form'>
      <label htmlFor={props.name}>{props.label}</label>
      <input
          required = {props.required}
          name={props.name}
          placeholder={props.placeholder} 
          type={props.type}
          onChange={props.onChange}
            />
    </div>
  )
}

export const FormSelect = (props) => {
  return(
    <div className="form">
      <label htmlFor={props.name}>{props.label}</label>
      <select 
        onChange={props.onChange}
        name={props.name}
        required
        >
          <option value="">Zgjedh</option>
          {Children.toArray(props?.objects?.map(object => (
            <option value={object?.id}>{object[props.objectName]}</option>
          )))}
        </select>
    </div>
  )
}

export const FormSelectQytetet = (props) => {
  return(
    <div className="form">
      <label htmlFor="qytetet">Qyteti</label>
      <select 
        onChange={props.onChange}
        name={props.name}
        required
        >
          <option value="">Zgjedh</option>
          {Children.toArray(qytetet.map(qyteti => (
            <option value={qyteti}>{qyteti}</option>
          )))}
        </select>
    </div>
  )
}