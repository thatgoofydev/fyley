import React, { FunctionComponent } from "react";
import { RequestState } from "@fyley/utils";
import { Loader, PageContent, PageError } from "@fyley/ui-lib";

import { useAccountList } from "../../../helpers/api/useAccountList/useAccountList";
import { AccountBlankSlate } from "../../AccountBlankSlate/AccountBlankSlate";
import { AccountOverview } from "../../AccountOverview/AccountOverview";

export const AccountPageContent: FunctionComponent = () => {
  const { state, data, refresh } = useAccountList();

  if (state === RequestState.LOADING) {
    return <Loader />;
  }

  if (state === RequestState.ERROR) {
    return (
      <PageContent>
        <PageError details="Failed to load data." />
      </PageContent>
    );
  }

  if (data.accounts.length === 0) {
    return (
      <PageContent>
        <AccountBlankSlate onSubmitted={refresh} />
      </PageContent>
    );
  }

  return (
    <>
      <AccountOverview accounts={data.accounts} />
    </>
  );
};
