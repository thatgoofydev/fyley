import React, { FunctionComponent } from "react";
import {
  LinkButton,
  List,
  ListItem,
  Loader,
  Sheet,
  SheetContent,
  SheetHeader
} from "@fyley/ui-lib";
import { useListDossiers } from "../helpers/api/useListDossiers";
import "./DossiersOverview.scss";

export const DossiersOverview: FunctionComponent = () => {
  return (
    <div className="dossier-overview-wrapper">
      <Sheet>
        <DossiersOverviewContent />
      </Sheet>
    </div>
  );
};

const DossiersOverviewContent: FunctionComponent = () => {
  const { loading, hasError, data } = useListDossiers();

  if (loading) {
    return <Loader />;
  }

  if (hasError) {
    return (
      <>
        <SheetHeader title="Oops" />
        <SheetContent>
          An error had occurred! Please contact an administrator.
        </SheetContent>
      </>
    );
  }

  if (data?.dossiers.length == 0) {
    return <>Create form for first dossier</>;
  }

  return (
    <>
      <SheetHeader
        title="Dossiers"
        buttons={<LinkButton text="Add dossier" icon="add" />}
      />
      <SheetContent>
        <List>
          {data?.dossiers.map(dossier => (
            <ListItem key={dossier.id}>{dossier.name}</ListItem>
          ))}
        </List>
      </SheetContent>
    </>
  );
};
