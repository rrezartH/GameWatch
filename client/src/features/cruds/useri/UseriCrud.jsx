import React, { useContext } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'

const BiznesiCrud = () => {

  const { bizneset } = useContext(GWContext)

  return (
    <>
      <h3>Bizneset</h3>
      <CrudTable apiObjects = {bizneset} />
    </>
  )
}

export default BiznesiCrud