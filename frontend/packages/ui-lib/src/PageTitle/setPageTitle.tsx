import React, { useContext, useEffect } from "react";
import { PageTitleContext } from "./PageTitleProvider";

export function setPageTitle(title: string) {
  const context = useContext(PageTitleContext);
  useEffect(() => {
    context.setTitle(title);
  });
}
