import React, { FunctionComponent } from "react";
import { RequestState } from "@fyley/utils";
import { Loader } from "@fyley/ui-lib";

import { useAccountList } from "../../../helpers/api/useAccountList/useAccountList";
import { AccountBlankSlate } from "./AccountBlankSlate/AccountBlankSlate";

export const AccountPageContent: FunctionComponent = () => {
  const { state, data } = useAccountList();

  if (state === RequestState.LOADING) {
    return <Loader />;
  }

  if (state === RequestState.ERROR) {
    return <>error</>;
  }

  console.log(data);

  if (data.accounts.length === 0) {
    return <AccountBlankSlate />;
  }

  return (
    <>
      <pre>{JSON.stringify(data, null, 2)}</pre>
    </>
  );
};