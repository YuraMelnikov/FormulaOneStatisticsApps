import React, { createContext } from 'react';
import { createRoot } from "react-dom/client";
import App from './App';
import reportWebVitals from './reportWebVitals';
import OpenApiStore from './store/OpenApiStore';

export const Context = createContext(null)

const rootElement = document.getElementById("root");
const root = createRoot(rootElement);

root.render(
  <Context.Provider value={{openApiData: new OpenApiStore(),}}>
    <App />
  </Context.Provider>
);

reportWebVitals();