import React, { useContext } from 'react'
import '../../cruds/crudStyles.scss'
import { GWContext } from '../../../context/GWContext'  

const BiznesiCrud = () => {

  const { bizneset } = useContext(GWContext)

  return (
    <>
      <h3>Bizneset</h3>
      <div className="table-wrapper">
        <table className="fl-table">
          <thead>
              <tr>
                <th>ID</th>
                <th>Emri</th>
                <th>Email</th>
                <th>Telefoni</th>
                <th>Qyteti</th>
                <th>Adresa</th>
                <th>Cmimorja</th>
                <th>Lokalet</th>
                <th>Update</th>
                <th>Delete</th>
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
                <td>Shfaq</td>
                <td><button>Update</button></td>
                <td><button>Delete</button></td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </>
  )
}

export default BiznesiCrud