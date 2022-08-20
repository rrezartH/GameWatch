import React, { useContext } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'

const CmimorjaCrud = () => {

  const { cmimorja } = useContext(GWContext)

  return (
    <>
      <h3>CmimorjaCrud</h3>
      <CrudTable apiObjects = {cmimoret} objectName="Cmimoret"/>
    </>
  )
}

export default CmimorjaCrud