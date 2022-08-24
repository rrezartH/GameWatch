import React, { useContext, useState } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'
import CreateBiznesiKonzolaVideoloja from './CreateBiznesiKonzolaVideoloja'

const BiznesiKonzolaVideolojaCrud = () => {

  const { bizneziKonzolaVideolojat } = useContext(GWContext)
  const [showCreate, setShowCreate] = useState(false);
  const[isForUpdate, setIsForUpdate] = useState(false);
  const[biznesiKonzolaVideolojaId, setBiznesiKonzolaVideolojaId] = useState(0);

  return (
    <>
      <h3>BiznesiKonzolaVideolojaCrud</h3>
      <button onClick={() => {setShowCreate(!showCreate); 
                              setIsForUpdate(false)}}>Shto BizKonVid</button>
      <CrudTable 
        apiObjects={bizneziKonzolaVideolojat} 
        objectName="BizneziKonzolaVideolojat"
        showCreate={showCreate} 
        setShowCreate={setShowCreate}
        setIsForUpdate={setIsForUpdate}
        setObjectId={setBiznesiKonzolaVideolojaId}
        />
      {showCreate ? <CreateBiznesiKonzolaVideoloja 
                      showCreate={showCreate} 
                      setShowCreate={setShowCreate} 
                      setIsForUpdate={setIsForUpdate}
                      isForUpdate={isForUpdate}
                      biznesiKonzolaVideolojaId={biznesiKonzolaVideolojaId}
                      /> : null}

    </>
  )
}

export default BiznesiKonzolaVideolojaCrud