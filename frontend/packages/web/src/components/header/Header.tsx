import React, { FunctionComponent } from "react";
import { PageTitle, PageTitleProvider } from "@fyley/ui-lib";
import { Test } from "../test/Test";

export const Header: FunctionComponent = () => {
  return (
    <>
      <PageTitleProvider>
        <PageTitle />
        <Test />
      </PageTitleProvider>
    </>
  );
};
