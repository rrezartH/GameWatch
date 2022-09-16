import React, {useState} from 'react'
import Earnings from './Earnings'
import ItemsTable from '../../../components/tables/ItemsTable'
import { FATURAT_E_LOKALIT_KEY, useFaturatELokalit } from '../../../hooks/useBiznesiKonzola'
import ScaleLoader from "react-spinners/ScaleLoader";



const Faturat = () => { 

  const[pageNumber, setPageNumber] = useState(1);

  const lokaliId = 1;

  //TODO: introduce the mutate function to enhance paginating
  const { isLoading: isFaturatLoading, data: faturat} = useFaturatELokalit(lokaliId, pageNumber)

  if (isFaturatLoading ) {
    return <ScaleLoader
              size={150}
              color={"#4bc3b5"}
              loading={isFaturatLoading}
              speedMultiplier={1.5}
            />
  }

  return (
    <>
      <Earnings />
        <ItemsTable
        apiObjects={faturat.length > 0 ? faturat : setPageNumber((prev) => --prev)}
        setPageNumber={setPageNumber}
        queryKey={FATURAT_E_LOKALIT_KEY}
        />
    </>
  )
}

export default Faturat