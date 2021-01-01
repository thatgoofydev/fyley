import React, { FunctionComponent } from "react";
import { Link, useHistory, useLocation } from "react-router-dom";
import { AccountForm } from "../AccountForm/AccountForm";
import {
  defineAccount,
  AccountFormViewModel,
  AccountNumberType
} from "../../helpers/api/defineAccount";

import styles from "./AccountNew.module.scss";

export const AccountNew: FunctionComponent = () => {
  const location = useLocation();
  const history = useHistory();
  const parentRoute = location.pathname.slice(0, -3);

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
            <Link to={parentRoute}>Accounts</Link> / Add new
          </h2>
        </div>
      </header>
      <AccountForm account={initialValues} onSubmit={defineAccount} onSubmitted={onSubmitted} />
    </>
  );
};
