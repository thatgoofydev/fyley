import React from "react";
import ReactDOM from "react-dom";
import { BaseStyleSetup } from "@fyley/ui-lib";

import App from "./App";
import { BrowserRouter, Switch } from "react-router-dom";

ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter>
      <BaseStyleSetup>
        <App />
      </BaseStyleSetup>
    </BrowserRouter>
  </React.StrictMode>,
  document.getElementById("root")
);
