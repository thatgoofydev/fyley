import React, { FunctionComponent } from "react";
import { Switch } from "react-router";
import { Route, useRouteMatch } from "react-router-dom";
import { Page } from "@fyley/ui-lib";

export const FinancialContent: FunctionComponent = () => {
  const { path } = useRouteMatch();

  return (
    <Switch>
      <Route path={`${path}/overview`}>
        <Page title="Overview">financial overview page</Page>
      </Route>
      <Route path={`${path}/accounts`}>
        <Page title="Accounts">accounts overview page</Page>
      </Route>
    </Switch>
  );
};
