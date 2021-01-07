import React, { FunctionComponent } from "react";
import { Route, Switch } from "react-router-dom";
import { AccountsPage } from "../Accounts/AccountsPage/AccountsPage";

export const FinancialContent: FunctionComponent = () => {
  return (
    <Switch>
      <Route path="/financial/overview">overview</Route>
      <Route path="/financial/accounts">
        <AccountsPage />
      </Route>
    </Switch>
  );
};
