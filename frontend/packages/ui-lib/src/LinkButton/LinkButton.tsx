import React, { FunctionComponent } from "react";
import classNames from "classnames";
import { Icon, IconType } from "../Icon";
import "./LinkButton.scss";

export interface IProps {
  text: string;
  icon?: IconType;
  href?: string;
  onClick?: (event: React.MouseEvent<HTMLDivElement, MouseEvent>) => void;
}

export const LinkButton: FunctionComponent<IProps> = ({
  text,
  icon = undefined,
  href = undefined,
  onClick = undefined
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
      <div role="button" className={classes} onClick={onClick}>
        {renderContent()}
      </div>
    );
  };

  return <>{href ? renderAnchor() : renderButton()}</>;
};
