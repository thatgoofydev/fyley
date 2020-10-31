import React, { FunctionComponent } from "react";
import classNames from "classnames";
import { Icon, IconType } from "../Icon";
import "./LinkButton.scss";

export interface IProps {
  text: string;
  icon?: IconType;
  href?: string;
}

export const LinkButton: FunctionComponent<IProps> = ({
  text,
  icon = undefined,
  href = undefined
}) => {
  const classes = classNames("link-button");

  const renderContent = () => {
    return (
      <>
        {icon && <Icon type={icon} size={14} />}
        <span>{text}</span>
      </>
    );
  };

  const renderAnchor = () => {
    return (
      <a className={classes} href={href}>
        {renderContent()}
      </a>
    );
  };

  const renderButton = () => {
    return (
      <div className={classes} role="button">
        {renderContent()}
      </div>
    );
  };

  return <>{href ? renderAnchor() : renderButton()}</>;
};
