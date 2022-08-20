import React, { useContext } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'

const BiznesiKonzolaVideolojaCrud = () => {

  const { bizneziKonzolaVideolojat } = useContext(GWContext)

  return (
    <>
      <h3>BiznesiKonzolaVideolojaCrud</h3>
      <CrudTable apiObjects = {bizneziKonzolaVideolojat} />
    </>
  )
}

export default BiznesiKonzolaVideolojaCrud