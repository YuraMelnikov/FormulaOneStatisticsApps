import React, { createContext } from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import reportWebVitals from './reportWebVitals';
import OpenApiStore from './store/OpenApiStore';

export const Context = createContext(null)

ReactDOM.render(
  <Context.Provider value={{
      openApiData: new OpenApiStore(),
  }}>
      <App />
</Context.Provider>,
  document.getElementById('root')
);

reportWebVitals();
