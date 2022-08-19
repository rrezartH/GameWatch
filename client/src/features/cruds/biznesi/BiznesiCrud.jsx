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
      <h3>Bizneset</h3>
      <div class="table-wrapper">
        <table class="fl-table">
          <thead>
              <tr>
                <th>ID</th>
                <th>Emri</th>
                <th>Email</th>
                <th>Telefoni</th>
                <th>Qyteti</th>
                <th>Cmimorja</th>
                <th>Lokalet</th>
              </tr>
          </thead>
          <tbody>
            {bizneset.map(biznesi => (
              <tr key={biznesi.id}>
                <td>{biznesi.id}</td>
                <td>{biznesi.emri}</td>
                <td>{biznesi.email}</td>
                <td>{biznesi.nrTel}</td>
                <td>{biznesi.qyteti}</td>
                <td>{biznesi.adresa}</td>
                <td>Shfaq</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </>
  )
}

export default BiznesiCrud