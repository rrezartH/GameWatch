import React, { useContext } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'
const KonzolatCrud = () => {
    const { konzolat } = useContext(GWContext)

    return (
        <>
            <h3>Konzolat</h3>
            <CrudTable apiObjects = {konzolat} />
        </>
    )
}

export default KonzolatCrud