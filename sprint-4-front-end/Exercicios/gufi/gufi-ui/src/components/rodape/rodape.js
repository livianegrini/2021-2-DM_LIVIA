import React from 'react'

 export default function Rodape(){
 
    var Data = new Date();
    var Ano = Data.getFullYear();

      return(
            <footer className="rodapePrincipal">
                <section className="rodapePrincipal-patrocinadores">
                <div className="container">
                    <p>Escola SENAI de Informática - {Ano}</p>
                </div>
                </section>
            </footer>
      )
}

