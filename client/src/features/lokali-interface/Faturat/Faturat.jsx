import React, {useState} from 'react'
import Earnings from './Earnings'
import ItemsTable from '../../../components/tables/ItemsTable'
import { FATURAT_E_LOKALIT_KEY, useFaturatELokalit } from '../../../hooks/useBiznesiKonzola'


const Faturat = () => { 

  const[pageNumber, setPageNumber] = useState(1);
  console.log(pageNumber);

  const lokaliId = 1;

  const { isLoading: isFaturatLoading, data: faturat} = useFaturatELokalit(lokaliId, pageNumber)

  return (
    <>
      <Earnings />
      {isFaturatLoading ? 
        "Te dhenat duke u ngarkuar"
        : 
        <ItemsTable
        apiObjects={faturat}
        setPageNumber={setPageNumber}
        queryKey={FATURAT_E_LOKALIT_KEY}
        />}
    </>
  )
}

export default Faturat