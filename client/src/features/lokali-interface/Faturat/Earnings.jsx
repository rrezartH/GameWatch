import React, {useState, useEffect} from 'react'
import agent from '../../../api/agents';

const Earnings = () => {
    const [period, setPeriod] = useState("daily");
    const [earningsByPeriod, setEarningsByPeriod ] = useState(0);

    const earningsPeriodDictionary = {
        "daily": "ditor",
        "weekly": "javor",
        "monthly": "mujor"
    }

    useEffect(() => {
        agent.Faturat.listEarningsByPeriod(period, 1)
            .then(response => {  
                setEarningsByPeriod(response);
            }); 
    },[period])

  return (
    <>
        <h3>Fitimi juaj {earningsPeriodDictionary[period]} eshte: {earningsByPeriod}€</h3>
        <select 
            name="earningsPeriod" 
            onChange={(e) => setPeriod(e.target.value)}
            defaultValue={period}
            >
            <option value="daily">Fitimi Ditor</option>
            <option value="weekly">Fitimi Javor</option>
            <option value="monthly">Fitimi Mujor</option>
        </select>
    </>
  )
}

export default Earnings