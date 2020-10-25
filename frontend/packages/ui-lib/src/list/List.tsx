import React, { FunctionComponent } from "react";
import classNames from "classnames";
import "./List.scss";

export interface ListProps {
  type?: "normal" | "compact" | undefined;
}

export const List: FunctionComponent<ListProps> = ({
  type = "normal",
  children
}) => {
  const classes = classNames("list", "list-" + type);
  return <div className={classes}>{children}</div>;
};

export const ListItem: FunctionComponent = ({ children }) => {
  return <div className="list-item">{children}</div>;
};
