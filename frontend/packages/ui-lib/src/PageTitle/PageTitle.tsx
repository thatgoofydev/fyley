import React, { FunctionComponent, useContext } from "react";
import { PageTitleContext } from "./PageTitleProvider";

export const PageTitle: FunctionComponent = () => {
  return (
    <>
      <PageTitleContext.Consumer>{({ title }) => <>{title}</>}</PageTitleContext.Consumer>
    </>
  );
};
