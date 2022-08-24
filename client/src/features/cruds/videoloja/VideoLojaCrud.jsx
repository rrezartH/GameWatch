import React, { useState, useContext } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'
import CreateVideoloja from './CreateVideoloja'

const VideoLojaCrud = () => {

  const { videoLojat } = useContext(GWContext)
  const[showCreate, setShowCreate] = useState(false);
  const[isForUpdate, setIsForUpdate] = useState(false);
  const[videoLojaId, setVideoLojaId] = useState(0);

  return (
    <>
      <h3>VideoLojat</h3> 
      <button onClick={() => {setShowCreate(!showCreate); 
                              setIsForUpdate(false)}}>Shto Videoloje</button>
      <CrudTable 
        apiObjects={videoLojat} 
        objectName="VideoLojat"
        showCreate={showCreate} 
        setShowCreate={setShowCreate}
        setIsForUpdate={setIsForUpdate}
        setObjectId={setVideoLojaId}
        />
      {showCreate ? <CreateVideoloja 
                      showCreate={showCreate} 
                      setShowCreate={setShowCreate} 
                      setIsForUpdate={setIsForUpdate}
                      isForUpdate={isForUpdate}
                      videoLojaId={videoLojaId}
                      /> : null}

    </>
  )
}

export default VideoLojaCrud