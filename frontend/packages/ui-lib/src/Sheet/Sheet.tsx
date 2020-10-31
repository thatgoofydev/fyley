import React, { FC, FunctionComponent, ReactNode } from "react";
import "./Sheet.module.scss";

/* Sheet */

export const Sheet: FunctionComponent = ({ children }) => {
  return <div className="sheet">{children}</div>;
};

/* Header */

interface ISheetHeaderProps {
  title: string;
  buttons?: ReactNode;
}

export const SheetHeader: FunctionComponent<ISheetHeaderProps> = ({ title, buttons }) => {
  return (
    <>
      <div className="sheet__header">
        <h1>{title}</h1>
        {buttons && <div>{buttons}</div>}
      </div>
    </>
  );
};

/* Content */

export const SheetContent: FC = ({ children }) => {
  return <div className="sheet__content">{children}</div>;
};
