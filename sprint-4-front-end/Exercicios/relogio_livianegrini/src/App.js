import React from 'react';
import './App.css';

function DataFormatada(props){
  return <h2>Horário Brasil: {props.date.toLocaleTimeString()}</h2>
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
    this.timerID = setInterval( () => {
      this.thick()
    }, 1000 )

   // Exibe no console o ID de cada relógio
   console.log('Eu sou o relógio ' + this.timerID);
  }
  

  // Ciclo de vida que ocorre quando Clock é removido na DOM
  // Morte
  // Quando isso acontece, a função clearInterval() limpa o relógio criado pela setInterval
  componentWillUnmount(){
    clearInterval(this.timerID)
  }

  // Simula as batidas do relógio
  thick(){
    this.setState({
      date : new Date()
    })
  }

  PausarRelogio(){

    clearInterval(this.timerID);

    // Exibe no console o ID de cada relógio
    console.log('Relógio ' + this.timerID + ' pausado!');
  }

  RetomarRelogio(){

    this.timerID = setInterval( () => {
      this.thick()
    }, 1000 )

    // Exibe no console o ID de cada relógio
    console.log('Relógio retomado!');
    console.log('Agora eu sou o relógio ' + this.timerID);
  }

  render(){
    return(
      <div> 
        <h1>Relógio</h1>
        <DataFormatada date={this.state.date}/>
        <div className="Botoes">
         <button className="BotaoPausar" onClick={() => {this.PausarRelogio()}}>Pausar</button>
         <button className="BotaoRetomar" onClick={() => {this.RetomarRelogio()}}>Retomar</button>
        </div>
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
