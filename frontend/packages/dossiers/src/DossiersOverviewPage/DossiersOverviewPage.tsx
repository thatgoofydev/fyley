import React, { FC } from "react";
import { Loader, setPageTitle, Sheet } from "@fyley/ui-lib";
import { RequestState } from "@fyley/utils";
import { useDossiersOverview } from "../helpers/api/useDossiersOverview";

import { DossiersOverview } from "../DossiersOverview";
import { DossierOnboarding } from "../DossierOnboarding";

export const DossiersOverviewPage: FC = () => {
  const { state, data, refresh } = useDossiersOverview();
  setPageTitle("hello");

  if (state == RequestState.LOADING) {
    return (
      <Sheet>
        <Loader />
      </Sheet>
    );
  }

  if (state == RequestState.ERROR) {
    return (
      <Sheet>
        {/*<ErrorPage title="Oops.. failed to load dossiers.">*/}
        {/*  <p>*/}
        {/*    Something went wrong attempting to load the required data.*/}
        {/*    <br /> please try again later.*/}
        {/*  </p>*/}
        {/*</ErrorPage>*/}
        error
      </Sheet>
    );
  }

  const renderContent = () => {
    const hasDossiers = data!.dossiers.length != 0;
    return hasDossiers ? (
      <DossiersOverview dossiers={data!.dossiers} />
    ) : (
      <DossierOnboarding onSubmit={refresh} />
    );
  };

  return <Sheet>{renderContent()}</Sheet>;
};
