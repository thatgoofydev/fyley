import React, { FC } from "react";
import ReactDom from "react-dom";
import { DossiersOverviewPage } from "../src/DossiersOverviewPage";

const Example: FC = () => {
  return (
    <main>
      <h1>Dossiers Example App</h1>
      <div className="example-wrapper">
        <DossiersOverviewPage />
      </div>
    </main>
  );
};

ReactDom.render(<Example />, document.getElementById("root"));

// import fetchMock from "fetch-mock";
// fetchMock.mock("/dossiers/overview-dossiers", async () => {
//   await new Promise(resolve => setTimeout(resolve, 1000));
//   return {
//     status: 200,
//     body: JSON.stringify({
//       ok: true,
//       data: {
//         dossiers: [
//           { id: "1", name: "test-dossier" },
//           { id: "2", name: "test-dossier" }
//         ]
//       }
//     })
//   };
// });
