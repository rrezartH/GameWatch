import React, { useState, useContext } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'
import CreateVideoloja from './CreateVideoloja'

const VideoLojaCrud = () => {

  const { videoLojat } = useContext(GWContext)
  const[showCreate, setShowCreate] = useState(false);

  return (
    <>
      <h3>VideoLojat</h3>
      <button onClick={() => setShowCreate(!showCreate)}>Shto Videoloje</button>
      <CrudTable apiObjects = {videoLojat} objectName="VideoLojat"/>
      {showCreate ? <CreateVideoloja showCreate={showCreate} setShowCreate={setShowCreate} /> : null}

    </>
  )
}

export default VideoLojaCrud