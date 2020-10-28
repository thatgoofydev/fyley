import React, { FunctionComponent, ReactNode } from "react";
import { Icon } from "../icons";
import "./ErrorPage.scss";

export interface IProps {
  title: string;
  children?: ReactNode;
}

export const ErrorPage: FunctionComponent<IProps> = ({ title, children }) => {
  return (
    <div className="error-page">
      <div className="error-page__icon">
        <Icon type="warning" size={200} />
      </div>
      <h1 className="error-page__title">{title}</h1>
      {children && <div className="error-page__content">{children}</div>}
    </div>
  );
};
