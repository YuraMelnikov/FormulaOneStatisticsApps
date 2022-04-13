import React, { createContext } from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import reportWebVitals from './reportWebVitals';
import MockStore from './store/MockStore';
import OpenApiStore from './store/OpenApiStore';

export const Context = createContext(null)

ReactDOM.render(
  <Context.Provider value={{
      mockData: new MockStore(),
      openApiData: new OpenApiStore(),
  }}>
      <App />
</Context.Provider>,
  document.getElementById('root')
);

reportWebVitals();
