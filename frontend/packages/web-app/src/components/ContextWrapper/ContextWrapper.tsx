import React, { FunctionComponent } from "react";
import { PageTitleProvider } from "@fyley/ui-lib";

export const ContextWrapper: FunctionComponent = ({ children }) => {
  return (
    <>
      <PageTitleProvider>{children}</PageTitleProvider>
    </>
  );
};
