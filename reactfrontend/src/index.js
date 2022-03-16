import React, { createContext } from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import reportWebVitals from './reportWebVitals';
import MockStore from './store/MockStore';

export const Context = createContext(null)

ReactDOM.render(
  <Context.Provider value={{
      mockData: new MockStore(),
  }}>
      <App />
</Context.Provider>,
  document.getElementById('root')
);

reportWebVitals();
