import { render } from '@testing-library/react';
import react from 'react';
import { Component } from 'react';
import './App.css';

export default class Repositorios extends Component{
  constructor(props){
    super(props),
    this.state = {
      ListaRepositorios : [],
      Username : ''
    }
  };

  BuscarPerfil = (element) => {
    element.pre
    console.log('realizando a chamada para a API!')

    fetch('https://api.github.com/users/' + this.state.Username + '/repos?per_page=10&sort=author-date-desc')
    .then(resposta => (resposta.json()))
    .then(dados => this.setState({ listaUsuarios: dados }))
    
    .catch(erro => console.log(erro))
  }

  AtualizarNome = async (event) => {

    await this.setState({
        Username : event.target.value
    });

    console.log(this.state.Username);
};

 
  render(){
    return(
      <div>
        <main>
         <section> 
         <form onSubmit={this.BuscarPerfil} >
          <div>
            <h1>Consultar Repositórios</h1>

             <p>Insira o username que deseja procurar!</p>

             <input type="text"
               value={this.state.Username}
               placeholder="Digite o Username"
               id="input_user"
               onChange={this.AtualizarNome}
             />

           <button type="submit">Procurar</button>

           </div>

           </form>
            <h2>Usuário encontrado</h2>
              <table>
                <thead>
                  <div>
                   <tr>
                   <th>Nome </th>
                   <th>Descrição</th>
                   <th>Id</th>
                   <th>Data de criação</th>
                   <th>Tamanho</th>
                   </tr>
                   </div>
                </thead>

                <tbody>{
                  this.state.ListaRepositorios.map((user) => {
                   return (
                     <tr>
                     <td>{user.name}</td>
                     <td>{user.description}</td>
                     <td>{user.id}</td>
                     <td>{user.created_at}</td>
                     <td>{user.size}</td>
                     </tr>
                    )
                   })
                 }
                </tbody>
              </table>
         </section>
        </main>
      </div>
    )
  }
};
