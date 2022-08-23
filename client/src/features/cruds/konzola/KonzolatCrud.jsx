import React, { useContext, useState } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'
import CreateKonzole from './CreateKonzole'

const KonzolatCrud = () => {
    const { konzolat } = useContext(GWContext)
    const[showCreate, setShowCreate] = useState(false);

    return (
        <>
            <h3>Konzolat</h3>
            <button onClick={() => setShowCreate(!showCreate)}>Shto Konzole</button>
            <CrudTable apiObjects = {konzolat} objectName= "Konzolat"/>
            {showCreate ? <CreateKonzole showCreate={showCreate} setShowCreate={setShowCreate} /> : null}
        </>
    )
}

export default KonzolatCrud