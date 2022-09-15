import React from 'react'
import './_crud-table.scss'

function ItemsTable(props) {
    const { apiObjects, setPageNumber } = props;
    const apiObjectKeys = apiObjects.length > 0 ? Object.keys(apiObjects[0]) : null;
    const capitalizeFirst = str => {
        return str.charAt(0).toUpperCase() + str.slice(1);
    };

    const handleNextOrPrevious = (isNext) => {
        setPageNumber((prev) => isNext? prev + 1 : prev - 1)
    }

    return (
        <>
            <div className="table-wrapper">
                <table className="fl-table">
                <thead>
                    <tr>
                        {React.Children.toArray(
                            apiObjectKeys?.map(objectKey => (
                                <th>{capitalizeFirst(objectKey)}</th>
                        )))}
                    </tr>
                </thead>
                {/*Here I map the objects I get from the api and then I get their member by their keys which i stored in line 7 */}
                <tbody>
                    {React.Children.toArray(
                        apiObjects?.map(object => (
                            <tr key={object.id}>
                                {React.Children.toArray(
                                    apiObjectKeys.map(member => (
                                        <td>{object[member]}</td>
                                )))}
                            </tr>
                    )))}
                </tbody>
                </table>
            </div>

            <button onClick={() => handleNextOrPrevious(true)}>Faqja e ardhshme</button>
            <button onClick={() => handleNextOrPrevious(false)}>Faqja e kaluar</button>
        </>
    );
}

export default ItemsTable