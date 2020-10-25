import React, { FunctionComponent, useEffect } from "react";
import { usePageTitle } from "@fyley/ui-lib";

export const Test: FunctionComponent = () => {
  const { setTitle } = usePageTitle();

  useEffect(() => {
    setTitle("Test Component");
  });

  const changeTitle = () => {
    setTitle(Math.random() + "");
  };

  return (
    <>
      <h1>
        test <button onClick={changeTitle}>change title</button>
      </h1>
    </>
  );
};
