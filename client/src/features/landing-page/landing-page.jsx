import React from 'react';
import Logo from '../../img/logo-assets/logo-color.svg'
import BiznesiCrud from '../cruds/biznesi/BiznesiCrud';

export default function LandingPage() {

    return(
        <>
            <main>
                <img src={Logo} className = 'logo'/>
                <p>Mate kohen pa humbur kohe!</p>
                <button type='button'>Kyqu</button>
                <BiznesiCrud />
            </main>
        </>
    )
}