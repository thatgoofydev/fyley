import React, { FunctionComponent, useEffect, useState } from "react";
import { Account } from "../../helpers/api/useAccountList/models";
import { AccountForm } from "../AccountForm/AccountForm";
import { IAccountFormModel } from "../../helpers/api/submitAccount/models";

import styles from "./AccountOverview.module.scss";
import classNames from "classnames";

interface IAccountOverviewProps {
  accounts: Account[];
}

export const AccountOverview: FunctionComponent<IAccountOverviewProps> = ({ accounts }) => {
  const [selected, setSelected] = useState(accounts[0].accountId);

  const selectedAccount = accounts.filter(account => account.accountId === selected)[0];
  const formModel: IAccountFormModel = {
    ...selectedAccount
  };

  return (
    <div className={styles.overviewWrapper}>
      <ul>
        {accounts.map(account => (
          <li
            key={account.accountId}
            onClick={() => setSelected(account.accountId)}
            className={classNames({ [styles.selected]: selected === account.accountId })}
          >
            {account.name}
          </li>
        ))}
      </ul>
      <div className={styles.formWrapper}>
        <AccountForm id={selected} account={formModel} onSubmitted={() => {}} key={selected} />
      </div>
    </div>
  );
};
