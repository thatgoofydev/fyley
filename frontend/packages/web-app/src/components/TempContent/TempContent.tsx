import React, { FunctionComponent } from "react";
import { setPageTitle } from "@fyley/ui-lib";

interface IProps {
  name: string;
}

export const TempContent: FunctionComponent<IProps> = ({ name }) => {
  setPageTitle(name);

  return (
    <>
      <p>Some {name} content</p>
    </>
  );
};
