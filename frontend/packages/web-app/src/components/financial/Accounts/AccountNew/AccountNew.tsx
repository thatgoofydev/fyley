import React, { FunctionComponent } from "react";
import { Link, useHistory, useLocation } from "react-router-dom";
import { AccountForm } from "../AccountForm/AccountForm";

import styles from "./AccountNew.module.scss";
import { AccountFormViewModel, AccountNumberType, defineAccount } from "./defineAccount";

export const AccountNew: FunctionComponent = () => {
  const { pathname } = useLocation();
  const history = useHistory();
  const parentRoute = pathname.substring(0, pathname.lastIndexOf("/"));

  const initialValues: AccountFormViewModel = {
    name: "",
    description: "",
    accountNumber: {
      value: "",
      type: AccountNumberType.Iban
    }
  };

  const onSubmitted = () => {
    history.push(parentRoute);
  };

  return (
    <>
      <header className={styles.pageHeader}>
        <div className={styles.headerTop}>
          <h2>
            <Link to={parentRoute}>Account</Link> / Add new
          </h2>
        </div>
      </header>
      <AccountForm data={initialValues} onSubmit={defineAccount} onSubmitted={onSubmitted} />
    </>
  );
};
