import React from "react";
import ReactDOM from "react-dom";
import { BaseStyleSetup } from "@fyley/ui-lib";
import { BrowserRouter } from "react-router-dom";

import App from "./App";
import "./index.scss";

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
