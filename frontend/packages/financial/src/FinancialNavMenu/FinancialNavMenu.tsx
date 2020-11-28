import React, { FunctionComponent } from "react";
import { NavLink } from "react-router-dom";

export interface IFinancialNavMenuProps {
  isOpen: boolean;
  baseRoute: string;
  onClick: () => void;
}

export const FinancialNavMenu: FunctionComponent<IFinancialNavMenuProps> = ({
  isOpen,
  baseRoute,
  onClick
}) => {
  if (!isOpen) return <></>;

  return (
    <ul>
      <li>
        <NavLink to={`${baseRoute}/overview`} onClick={onClick} activeClassName="active">
          Overview
        </NavLink>
      </li>
      <li>
        <NavLink to={`${baseRoute}/accounts`} onClick={onClick}>
          Accounts
        </NavLink>
      </li>
    </ul>
  );
};
