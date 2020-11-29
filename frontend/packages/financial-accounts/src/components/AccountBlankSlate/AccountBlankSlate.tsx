import React, { FunctionComponent } from "react";
import styles from "./AccountBlankSlate.module.scss";

import { AccountForm } from "../AccountForm/AccountForm";
import { AccountNumberType, IAccountFormModel } from "../../helpers/api/submitAccount/models";

interface IAccountBlankSlateProps {
  onSubmitted: () => void;
}

export const AccountBlankSlate: FunctionComponent<IAccountBlankSlateProps> = ({ onSubmitted }) => {
  const model: IAccountFormModel = {
    name: "",
    description: "",
    accountNumber: "",
    accountNumberType: AccountNumberType.IBAN
  };

  return (
    <>
      <h2 className={styles.heading}>Create your first account</h2>
      <p className={styles.description}>
        Accounts are your virtual ledgers in Fyley. They are used for tracking expense and income
        transactions of bank or other financial accounts.
      </p>
      <div className={styles.formWrapper}>
        <AccountForm account={model} onSubmitted={onSubmitted} />
      </div>
    </>
  );
};
