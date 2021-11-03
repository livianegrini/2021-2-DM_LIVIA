import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import BuscarUsuario from './pages/BuscarUsuario';
import reportWebVitals from './reportWebVitals';
 
const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} /> 
        <Route path="/BuscarUsuario" component={Username} /> 
        <Route path="/notFound" component={NotFound} /> 
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(
  <React.StrictMode>
    <BuscarUsuario />
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
