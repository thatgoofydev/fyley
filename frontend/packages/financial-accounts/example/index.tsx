import React, { FC } from "react";
import ReactDom from "react-dom";
import { AccountPage } from "../src";
import { BrowserRouter } from "react-router-dom";

const ExampleApp: FC = () => {
  return (
    <BrowserRouter>
      <main>
        <AccountPage />
      </main>
    </BrowserRouter>
  );
};

ReactDom.render(<ExampleApp />, document.getElementById("root"));
