import React, { useContext, useState } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'
import CreateKonzole from './CreateKonzole'

const KonzolatCrud = () => {
    const { konzolat } = useContext(GWContext)
    const[showCreate, setShowCreate] = useState(false);
    const[isForUpdate, setIsForUpdate] = useState(false);
    const[konzolaId, setKonzolaId] = useState(0);
  

    return (
        <>
            <h3>Konzolat</h3>
            <button onClick={() => {setShowCreate(!showCreate); 
                              setIsForUpdate(false)}}>Shto Konzole</button>
            <CrudTable 
                apiObjects={konzolat} 
                objectName= "Konzolat"
                showCreate={showCreate} 
                setShowCreate={setShowCreate}
                setIsForUpdate={setIsForUpdate}
                setObjectId={setKonzolaId}
                />
            {showCreate ? <CreateKonzole 
                            showCreate={showCreate} 
                            setShowCreate={setShowCreate} 
                            setIsForUpdate={setIsForUpdate}
                            isForUpdate={isForUpdate}
                            konzolaId={konzolaId}
                            /> : null}
        </>
    )
}

export default KonzolatCrud