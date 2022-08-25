import React from 'react';
import Logo from '../../img/logo-assets/logo-color.svg'
import { Link } from 'react-router-dom';

export default function LandingPage() {

    return(
        <>
            <main>
                <img src={Logo} className = 'logo' alt='our logo'/>
                <p>Mate kohen pa humbur kohe!</p>
                <button type='button'><Link to='./Lokali'>Kyqu</Link></button>
            </main>
        </>
    )
}