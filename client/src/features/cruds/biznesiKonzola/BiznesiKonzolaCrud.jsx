import React, { useContext } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'

const BiznesiKonzolaCrud = () => {

  const { biznesiKonzolat } = useContext(GWContext)

  return (
    <>
      <h3>Bizneset</h3>
      <CrudTable apiObjects = {biznesiKonzolat} />
    </>
  )
}

export default BiznesiKonzolaCrud