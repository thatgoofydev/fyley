import React, { FC } from "react";
import ReactDom from "react-dom";
import { AccountPage } from "../src/components/AccountPage";

const ExampleApp: FC = () => {
  return (
    <main>
      <AccountPage />
    </main>
  );
};

ReactDom.render(<ExampleApp />, document.getElementById("root"));
