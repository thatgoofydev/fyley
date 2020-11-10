import React from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import { PageTitleProvider } from "@fyley/ui-lib";

import { Header } from "./components/Header";
import { Sidebar } from "./components/Sidebar";

import layout from "./base-styling/layout.module.scss";

function App() {
  return (
    <PageTitleProvider>
      <BrowserRouter>
        <div className={layout.container}>
          <header className={layout.header}>
            <Header />
          </header>
          <section className={layout.sidebar}>
            <Sidebar />
          </section>
          <main className={layout.content}>
            <Switch>
              <Route exact path="/">
                <h1>Dashboard</h1>
              </Route>
              <Route exact path="/transactions">
                <h1>Transactions</h1>
              </Route>
            </Switch>
          </main>
        </div>
      </BrowserRouter>
    </PageTitleProvider>
  );
}

export default App;
