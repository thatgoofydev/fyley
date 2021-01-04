import React, { FunctionComponent } from "react";
import { useHistory, useRouteMatch } from "react-router-dom";
import classNames from "classnames";
import { RequestState } from "@fyley/utils";
import { Loader } from "@fyley/ui-lib";

import { useAccountList } from "../../helpers/api/useAccountList/useAccountList";
import styles from "./AccountOverview.module.scss";

export const AccountOverview: FunctionComponent = () => {
  const { state, data } = useAccountList();
  const history = useHistory();
  const { path } = useRouteMatch();

  if (state === RequestState.LOADING) {
    return <Loader />;
  }

  if (state === RequestState.ERROR) {
    return <>error</>;
  }

  const { accounts } = data;

  if (accounts.length === 0) {
    return <>black slate</>;
  }

  const navigateToNew = () => {
    history.push(`${path}/new`);
  };

  const navigateToEdit = (id: string) => {
    history.push(`${path}/${id}`);
  };

  const archiveAccount = (id: string) => {
  };

  return (
    <>
      <header className={styles.pageHeader}>
        <div className={styles.headerTop}>
          <h2>Accounts</h2>
          <div className="buttons">
            <button onClick={navigateToNew} className={styles.button}>
              New account
            </button>
          </div>
        </div>
        <p className={styles.pageDescription}>
          Accounts are your virtual ledgers in Fyley. <br />
          They are used for tracking expense and income transactions of bank or other financial
          accounts.
        </p>
      </header>
      <div>
        {accounts.map(account => (
          <div className={styles.accountListItem} key={account.accountId}>
            <svg
              version="1.0"
              xmlns="http://www.w3.org/2000/svg"
              width="1365.3"
              height="1365.3"
              viewBox="0 0 1024 1024"
            >
              <path d="M108 34C61 41 21 76 6 121c-6 21-6-6-6 391s0 370 6 391c13 39 44 70 83 83 21 6-7 6 407 6 365 0 378 0 387-2 32-6 59-29 70-58 7-17 7-20 7-82v-55l6-3c21-8 43-30 51-52 7-19 7-14 7-132 0-117 0-113-7-132-8-22-30-44-51-52l-6-2v-72c0-79 0-80-7-98-8-22-30-44-51-52l-6-2v-40c0-35 0-41-2-48-8-39-37-68-75-76-9-2-21-2-356-2-283 0-348 0-355 2zm706 65c6 4 11 9 15 15l3 6v72H534l-304-1c-7-1-17-5-22-9l-7-9c-9-14-16-18-28-19-6 0-9 0-13 2-8 3-14 9-18 16-2 5-3 7-3 14 0 6 1 9 3 13a106 106 0 0072 55l333 2 326 1 5 2c6 4 11 9 15 15l3 6v136h-76c-82 1-79 1-102 7a192 192 0 000 370c23 6 20 6 102 7h76v52l-1 52-2 6c-4 6-9 11-15 15l-6 2-374 1c-339 0-375 0-382-2-26-5-46-25-51-49-2-12-2-718 0-729 4-20 17-37 35-46 15-6-14-6 365-6h343l6 3zm128 384c6 4 11 9 15 15l3 6v209l-3 5c-4 6-9 11-15 15l-5 3h-92c-102 0-99 0-119-7-31-11-58-35-73-64-9-18-12-35-12-57a121 121 0 0137-90c21-22 47-34 77-37l93-1 89 1 5 2z" />
              <path d="M756 562c-9 2-14 5-22 12a46 46 0 00-14 34c0 13 5 24 14 34 10 9 21 14 34 14s24-5 34-14c7-8 10-13 13-23 2-10 1-22-4-33-3-6-15-18-21-21-11-5-23-6-34-3z" />
            </svg>
            <span className={styles.name}>{account.name}</span>
            <span className={styles.description}>{account.description}</span>
            <div className={styles.buttonGroup}>
              <button
                onClick={() => navigateToEdit(account.accountId)}
                className={classNames(styles.button, styles.secondary)}
              >
                Edit
              </button>
              <button
                onClick={() => archiveAccount(account.accountId)}
                className={classNames(styles.button, styles.danger)}
              >
                Archive
              </button>
            </div>
          </div>
        ))}
      </div>
    </>
  );
};
