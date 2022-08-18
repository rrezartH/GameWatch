import React from 'react';
import { Link } from 'react-router-dom';


export default function Navbar() {

    return(
        <>
            <div className="navbar">
                <div className="first">
                    <div className="mid"></div>
                </div>
                <div className="second">
                    <p>Si ta perdor?</p>
                    <div className="mid">
                        <Link to="/"><p>Ballina</p> </Link>
                    </div>
                    <Link to="./Register"><p>Regjistrohu</p></Link>
                </div>
                <div className="third">
                    <div className="mid"></div>
                </div>
            </div>
        </>
    )
}