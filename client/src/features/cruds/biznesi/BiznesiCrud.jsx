import React, { useEffect, useState } from 'react'
import agent from '../../../api/agents'
import '../../cruds/crudStyles.scss'

const BiznesiCrud = () => {

  const [bizneset, setBizneset] = useState([])

  useEffect(() => {
    agent.Bizneset.list().then(response => {
      setBizneset(response);
    })
  },[])

  return (
    <>
    {bizneset.map(biznesi => (
      <ul key={biznesi.id} className="list" color='black'>
        <li>{biznesi.emri}</li>
      </ul>
    ))}
    </>
  )
}

export default BiznesiCrud