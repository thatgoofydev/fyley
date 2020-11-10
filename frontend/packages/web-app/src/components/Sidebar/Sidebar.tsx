import React, { FunctionComponent } from "react";
import { SidebarItem } from "./SidebarItem";
import "./Sidebar.scss";

export const Sidebar: FunctionComponent = () => {
  return (
    <>
      <div className="sidebar__wrapper">
        <header className="sidebar__header">Fyley</header>
        <nav>
          <SidebarItem to="/" text="Dashboard" icon="add" exact={true} />
          <SidebarItem to="/transactions" text="Transactions" icon="warning" />
        </nav>
      </div>
    </>
  );
};
