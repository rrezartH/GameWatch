import React, { useContext } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'

const VideoLojaCrud = () => {

  const { videoLojat } = useContext(GWContext)

  return (
    <>
      <h3>VideoLojat</h3>
      <CrudTable apiObjects = {videoLojat} />
    </>
  )
}

export default VideoLojaCrud