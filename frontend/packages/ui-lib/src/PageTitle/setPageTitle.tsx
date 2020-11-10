import React, { useContext } from "react";
import { PageTitleContext } from "./PageTitleProvider";

export function setPageTitle(title: string) {
  const context = useContext(PageTitleContext);
  context.setTitle(title);
}
