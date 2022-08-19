import React from 'react';
import Logo from '../../img/logo-assets/logo-color.svg'

export default function LandingPage() {

    return(
        <>
            <main>
                <img src={Logo} className = 'logo' alt='our logo'/>
                <p>Mate kohen pa humbur kohe!</p>
                <button type='button'>Kyqu</button>
            </main>
        </>
    )
}