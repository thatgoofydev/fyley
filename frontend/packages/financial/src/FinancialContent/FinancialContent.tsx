import React, { FunctionComponent } from "react";
import { Switch } from "react-router";
import { Route, useRouteMatch } from "react-router-dom";
import { Page } from "@fyley/ui-lib";
import { AccountPage } from "@fyley/financial-accounts";

export const FinancialContent: FunctionComponent = () => {
  const { path } = useRouteMatch();

  return (
    <Switch>
      <Route path={`${path}/overview`}>
        <Page title="Overview">financial overview page</Page>
      </Route>
      <Route path={`${path}/accounts`}>
        <AccountPage />
      </Route>
    </Switch>
  );
};
