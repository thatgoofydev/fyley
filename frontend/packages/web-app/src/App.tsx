import React from "react";
import { Switch, Route } from "react-router-dom";

import styles from "./App.module.scss";
import { Header } from "./components/layout";

import { FinancialContent } from "./components/financial";

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
