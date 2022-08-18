import React from "react";
import "./register.scss"

export default function Register() {

    return(
        <>
            <h1>Regjistrohu</h1>

            <div className="register-form">
                <form action="submit">
                    <label htmlFor="fullName">Emri & Mbiemri</label>
                    <input type="text" name="fullName" />
                    <label htmlFor="city">Qyteti</label>
                    <select name="city">
                        <option value="Qyteti">Qyteti</option>
                        <option>Gjilan</option>
                        {/*todo -> connect with api to show only cities in db */}
                    </select>
                    <label htmlFor="businnes">Biznesi ku punoni</label>
                    <select name="businnes">
                        <option value="Biznesi">Biznesi</option>
                        <option>PS Center</option>
                        {/*todo -> connect with api to show only businneses in db */}
                    </select>
                    <label htmlFor="lokali">Biznesi ku punoni</label>
                    <select name="lokali">
                        <option value="Lokali">Lokali</option>
                        <option>PSCenter 1</option>
                        {/*todo -> connect with api to show only lokalet in db, only available after choosing business */}
                    </select>

                    <button>Regjistrohu</button>
                </form>
            </div>
        </>
    )

}

// public int UserId { get; set; }
//         public string Emri { get; set; } = null!;
//         public string Qyteti { get; set; } = null!;
//         public string RoleName { get; set; } = null!;
//         public int? LokaliId { get; set; }
//         public int? BiznesiId { get; set; }