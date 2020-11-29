import React, { FunctionComponent } from "react";
import { Page } from "@fyley/ui-lib";

import { AccountPageContent } from "./AccountPageContent/AccountPageContent";

export const AccountPage: FunctionComponent = () => {
  return (
    <>
      <Page title="Accounts">
        <AccountPageContent />
      </Page>
    </>
  );
};
