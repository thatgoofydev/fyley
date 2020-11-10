import React, { FunctionComponent } from "react";
import { NavLink } from "react-router-dom";
import { Icon, IconType } from "@fyley/ui-lib";
import "./SidebarItem.scss";

interface IProps {
  exact?: boolean;
  to: string;
  text: string;
  icon: IconType;
}

export const SidebarItem: FunctionComponent<IProps> = ({ exact = false, to, text, icon }) => {
  return (
    <>
      <NavLink exact={exact} className="nav-item" activeClassName="active" to={to}>
        <Icon type={icon} size={20} />
        <span>{text}</span>
      </NavLink>
    </>
  );
};
