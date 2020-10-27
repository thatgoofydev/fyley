import React, { FunctionComponent } from "react";
import ReactDOM from "react-dom";
import { DossiersOverview } from "../src/DossiersOverview";

const DossiersExamples: FunctionComponent = () => {
  return (
    <main>
      <h1>Dossiers Example App</h1>
      <div className="example-wrapper">
        <DossiersOverview />
      </div>
    </main>
  );
};

ReactDOM.render(<DossiersExamples />, document.getElementById("root"));
