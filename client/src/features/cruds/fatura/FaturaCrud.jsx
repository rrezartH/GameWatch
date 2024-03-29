import React, { useContext } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/tables/CrudTable'

const FaturaCrud = () => {

  const { faturat } = useContext(GWContext)

  return (
    <>
      <h3>Faturat</h3>
      <CrudTable 
        apiObjects = {faturat}
        objectName="Faturat"
        />
    </>
  )
}

export default FaturaCrud