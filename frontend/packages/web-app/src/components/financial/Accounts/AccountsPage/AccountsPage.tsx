import React, { FunctionComponent } from "react";
import { Redirect, Route, Switch, useRouteMatch } from "react-router-dom";
import { AccountOverview } from "../AccountsOverview/AccountOverview";
import { AccountNew } from "../AccountNew/AccountNew";

import styles from "./AccountsPage.module.scss";

export const AccountsPage: FunctionComponent = () => {
  const { path } = useRouteMatch();

  return (
    <>
      <div className={styles.page}>
        <Switch>
          <Route path={`${path}`} exact component={AccountOverview} />
          <Route path={`${path}/new`} component={AccountNew} />
          <Route
            path={`${path}/:id([0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12})`}
            render={() => <>id</>}
          />
          <Redirect from="*" to="/notfound" />
        </Switch>
      </div>
    </>
  );
};
