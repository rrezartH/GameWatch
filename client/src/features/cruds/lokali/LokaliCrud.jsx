import React, { useContext } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'

const LokaliCrud = () => {
    const { lokalet } = useContext(GWContext)
  return (
    <>
      <h3>Lokalet</h3>
      <CrudTable apiObjects = {lokalet} />
    </>
  )
}

export default LokaliCrud