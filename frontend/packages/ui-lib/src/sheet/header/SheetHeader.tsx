import React, { FunctionComponent, ReactNode } from "react";
import "./SheetHeader.scss";

export interface SheetHeaderProps {
  title: string;
  buttons?: ReactNode;
}

export const SheetHeader: FunctionComponent<SheetHeaderProps> = ({
  title,
  buttons
}) => {
  return (
    <>
      <div className="sheet__header">
        <h1>{title}</h1>
        {buttons && <div>{buttons}</div>}
      </div>
    </>
  );
};
