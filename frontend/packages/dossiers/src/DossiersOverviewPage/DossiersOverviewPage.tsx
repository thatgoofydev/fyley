import React from "react";
import { ErrorPage, Loader, Sheet } from "@fyley/ui-lib";
import { useListDossiers } from "../helpers/api/useListDossiers";
import { DossiersOverview } from "../DossiersOverview";
import { DossierOnboarding } from "../DossierOnboarding";
import "./DossiersOverviewPage.scss";

export const DossiersOverviewPage = () => {
  const { loading, hasError, data, refresh } = useListDossiers();

  if (loading) {
    return (
      <Sheet>
        <Loader />
      </Sheet>
    );
  }

  if (hasError) {
    return (
      <Sheet>
        <ErrorPage title="Oops.. failed to load dossiers.">
          <p>
            Something went wrong attempting to load the required data.
            <br /> please try again later.
          </p>
        </ErrorPage>
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
