import React from 'react';
import './App.css';

function DataFormatada(props){
  return <h2>Horário Brasil: {props.date}</h2>
}

class Clock extends React.Component{

  constructor(props){
    super(props);
    this.state = {
      // Define o estado date pegando a data atual
      date : new Date()
    }
  }

  // Ciclo de vida que ocorre quando Clock é inserido na DOM
  // Nascimento
  componentDidMount(){

  }

  // Ciclo de vida que ocorre quando Clock é removido na DOM
  // Morte
  componentWillUnmount(){

  }

  render(){
    return(
      <div> 
        <h1>Relógio</h1>
        <DataFormatada date={this.state.date}/>
      </div>
    )
  }

}

function App() {
  return (
    <div className="App">
      <header className="App-header">
      <Clock />
      </header>
    </div>
  );
}

export default App;
