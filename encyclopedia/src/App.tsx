import React from 'react';
import {BrowserRouter} from 'react-router-dom';
import AppRouter from './components/AppRouter';
import NavBar from './components/NavBar';
import "./styles.css";

const App: React.FC = () => {
  return (
    <div className="App">
        <BrowserRouter>
            <NavBar/>
            <AppRouter/>
        </BrowserRouter>
    </div>
  );
}

export default App;