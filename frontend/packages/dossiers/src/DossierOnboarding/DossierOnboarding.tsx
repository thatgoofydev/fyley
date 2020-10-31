import React, { FunctionComponent } from "react";
import { SheetContent, SheetHeader } from "@fyley/ui-lib";
import { DossiersForm } from "../DossiersForm";

interface IProps {
  onSubmit?: () => void;
}

export const DossierOnboarding: FunctionComponent<IProps> = ({ onSubmit }) => {
  return (
    <>
      <SheetHeader title="Create your first dossier" />
      <SheetContent>
        <DossiersForm onSubmit={onSubmit} />
      </SheetContent>
    </>
  );
};
