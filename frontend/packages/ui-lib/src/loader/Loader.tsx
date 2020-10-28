import React, { FunctionComponent } from "react";
import "./Loader.scss";

export const Loader: FunctionComponent = () => {
  return (
    <div className="lds-ellipsis">
      <div></div>
      <div></div>
      <div></div>
      <div></div>
    </div>
  );
};
