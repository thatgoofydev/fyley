import React, { FC } from "react";
import ReactDom from "react-dom";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import { FinancialNavMenu } from "../src/FinancialNavMenu";
import { FinancialContent } from "../src/FinancialContent";

const Example: FC = () => {
  return (
    <main>
      <BrowserRouter>
        <nav>
          <FinancialNavMenu isOpen={true} baseRoute={"/financial"} onClick={() => {}} />
        </nav>
        <Switch>
          <Route path={"/financial"}>
            <FinancialContent />
          </Route>
        </Switch>
      </BrowserRouter>
    </main>
  );
};

ReactDom.render(<Example />, document.getElementById("root"));
