import React, { FunctionComponent } from "react";
import { Redirect, Route, Switch, useRouteMatch, useHistory } from "react-router-dom";

import { AccountOverview } from "../AccountOverview/AccountOverview";
import { AccountNew } from "../AccountNew";

import styles from "./AccountPage.module.scss";

export const AccountPage: FunctionComponent = () => {
  const { path } = useRouteMatch();

  console.log(path);

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
