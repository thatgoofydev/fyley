import React, { FunctionComponent } from "react";
import {
  LinkButton,
  List,
  ListItem,
  SheetContent,
  SheetHeader
} from "@fyley/ui-lib";
import { DossierDto } from "../helpers/api/useListDossiers";

interface IProps {
  dossiers: DossierDto[];
}

export const DossiersOverview: FunctionComponent<IProps> = ({ dossiers }) => {
  return (
    <>
      <SheetHeader
        title="Dossiers"
        buttons={<LinkButton text="Add dossier" icon="add" />}
      />
      <SheetContent>
        <List>
          {dossiers.map(dossier => (
            <ListItem key={dossier.id}>{dossier.name}</ListItem>
          ))}
        </List>
      </SheetContent>
    </>
  );
};
