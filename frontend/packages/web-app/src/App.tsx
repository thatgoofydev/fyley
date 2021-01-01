import React from "react";
import { Switch, Route } from "react-router-dom";
import { FinancialContent } from "@fyley/financial";

import styles from "./App.module.scss";
import { Header } from "./components/Header/Header";

function App() {
  return (
    <>
      <Header />
      <div className={styles.content}>
        <Switch>
          <Route path="/financial" component={FinancialContent} />
        </Switch>
      </div>
    </>
  );
}

export default App;
