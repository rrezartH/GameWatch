import React from 'react'
import agent from '../../api/agents';
import './_crud-table.scss'

function CrudTable(props) {
    const { apiObjects, objectName } = props;
    const apiObjectKeys = apiObjects.length > 0 ? Object.keys(apiObjects[0]) : "";
    const capitalizeFirst = str => {
        return str.charAt(0).toUpperCase() + str.slice(1);
    };

    function handleDelete(objectId) {
        const confirmBox = window.confirm(
            "A jeni i sigute se doni te vazhdoni me fshirjen e kesaj te dhene?"
        )
        if(confirmBox === true){
            agent[objectName].delete(objectId)
                .catch(error => console.log(error));
        }
    }

    return (apiObjects.length > 0) ? (
        <>
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
                            <td><button type='submit' onClick={() => {props.setShowCreate(!props.showCreate); props.setIsForUpdate(true); props.setObjectId(object.id)}}>Update</button></td>
                            <td><button type='submit' onClick={() => handleDelete(object.id)}>Delete</button></td>
                        </tr>
                    ))}
                </tbody>
                </table>
            </div>
        </>
    ) : "";
}

export default CrudTable