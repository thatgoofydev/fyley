import React, { FunctionComponent } from "react";
import classNames from "classnames";
import { Icon, IconType } from "../../icons";
import "./LinkButton.scss";

export interface LinkButtonProps {
  text: string;
  icon?: IconType;
  href?: string;
}

export const LinkButton: FunctionComponent<LinkButtonProps> = ({
  text,
  href = undefined,
  icon = undefined
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
