import React, { useContext, useState } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'
import CreateBiznesiKonzolaVideoloja from './CreateBiznesiKonzolaVideoloja'

const BiznesiKonzolaVideolojaCrud = () => {

  const { bizneziKonzolaVideolojat } = useContext(GWContext)
  const [showCreate, setShowCreate] = useState(false);

  return (
    <>
      <h3>BiznesiKonzolaVideolojaCrud</h3>
      <button onClick={() => setShowCreate(!showCreate)}>Shto BizKonVid</button>
      <CrudTable apiObjects = {bizneziKonzolaVideolojat} objectName="BizneziKonzolaVideolojat"/>
      {showCreate ? <CreateBiznesiKonzolaVideoloja showCreate={showCreate} setShowCreate={setShowCreate} /> : null}

    </>
  )
}

export default BiznesiKonzolaVideolojaCrud