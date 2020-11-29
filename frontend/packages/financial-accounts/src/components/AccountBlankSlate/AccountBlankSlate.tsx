import React, { FunctionComponent } from "react";
import styles from "./AccountBlankSlate.module.scss";

import { AccountForm, IAccountFormModel } from "../AccountForm/AccountForm";

export const AccountBlankSlate: FunctionComponent = () => {
  const model: IAccountFormModel = {
    name: "",
    description: "",
    accountNumber: ""
  };

  const onSubmit = (values: IAccountFormModel) => {
    console.log("Submitted:");
    console.log(values);

    // TODO submit to api
  };

  return (
    <>
      <h2 className={styles.heading}>Create your first account</h2>
      <p className={styles.description}>
        Accounts are your virtual ledgers in Fyley. They are used for tracking expense and income
        transactions of bank or other financial accounts.
      </p>
      <div className={styles.formWrapper}>
        <AccountForm account={model} onSubmit={onSubmit} />
      </div>
    </>
  );
};
