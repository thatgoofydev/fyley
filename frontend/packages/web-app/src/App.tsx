import React from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import { PageTitleProvider } from "@fyley/ui-lib";

import { Header } from "./components/Header";
import { Sidebar } from "./components/Sidebar";

import layout from "./base-styling/layout.module.scss";
import { TempContent } from "./components/TempContent/TempContent";

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
                <TempContent name="Dashboard" />
              </Route>
              <Route exact path="/transactions">
                <TempContent name="Transactions" />
              </Route>
            </Switch>
          </main>
        </div>
      </BrowserRouter>
    </PageTitleProvider>
  );
}

export default App;
