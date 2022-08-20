import React from 'react'
import './_crud-table.scss'

function CrudTable(props) {
    const { apiObjects } = props;
    const apiObjectKeys = apiObjects.length > 0 ? Object.keys(apiObjects[0]) : "";
    const capitalizeFirst = str => {
        return str.charAt(0).toUpperCase() + str.slice(1);
    };

    return (apiObjects.length > 0) ? (
        <div className="table-wrapper">
            <table className="fl-table">
            <thead>
                <tr>
                    {React.Children.toArray(
                        apiObjectKeys.map(objectKey => (
                            <th>{capitalizeFirst(objectKey)}</th>
                    )))}
                    <th>Update</th>
                    <th>Delete</th>
                </tr>
            </thead>
            <tbody>
                {apiObjects.map(object => (
                    <tr key={object.id}>
                        {React.Children.toArray(
                            apiObjectKeys.map(member => (
                                <td>{object[member]}</td>
                        )))}
                        <td><button>Update</button></td>
                        <td><button>Delete</button></td>
                    </tr>
                ))}
            </tbody>
            </table>
        </div>
    ) : "";
}

export default CrudTable