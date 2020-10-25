import React from "react";
import { Sidebar } from "./components/sidebar/Sidebar";
import "./App.scss";
import { Header } from "./components/header/Header";
import { Test } from "./components/test/Test";
import { PageTitle, PageTitleProvider } from "@fyley/ui-lib";

function App() {
  return (
    <>
      <div className="layout-container">
        <div className="layout-sidebar">
          <Sidebar />
        </div>
        <div className="layout-header">
          <Header />
        </div>
        <div className="layout-content">
          <p>Content</p>
          <PageTitleProvider>
            <PageTitle />
            <Test />
          </PageTitleProvider>
        </div>
      </div>
    </>
  );
}

export default App;
