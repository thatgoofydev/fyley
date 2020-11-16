import React, { FC, useImperativeHandle } from "react";
import ReactDom from "react-dom";
import { TransactionsOverview } from "../src/TransactionsOverview";
import "./index.scss";

const Example: FC = () => {
  return (
    <main>
      <TransactionsOverview />
    </main>
  );
};

ReactDom.render(<Example />, document.getElementById("root"));
