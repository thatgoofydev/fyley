import React, { FunctionComponent } from "react";
import ReactDOM from "react-dom";
import { DossiersOverviewPage } from "../src/";

const DossiersExamples: FunctionComponent = () => {
  return (
    <main>
      <h1>Dossiers Example App</h1>
      <div className="example-wrapper">
        <DossiersOverviewPage />
      </div>
    </main>
  );
};

ReactDOM.render(<DossiersExamples />, document.getElementById("root"));
