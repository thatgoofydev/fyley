import React, { FunctionComponent, useContext, useState } from "react";
import { PageTitleContext } from "./PageTitleProvider";

export const PageTitle: FunctionComponent = () => {
  const { getTitle } = useContext(PageTitleContext);

  return (
    <>
      <h1>{getTitle()}</h1>
    </>
  );
};
