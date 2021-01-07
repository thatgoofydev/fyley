import React, { FunctionComponent } from "react";
import { NavLink } from "react-router-dom";
import { NavMenu } from "./NavMenu/NavMenu";

import styles from "./Header.module.scss";

export const Header: FunctionComponent = () => {
  return (
    <header className={styles.header}>
      <div className={styles.logo}>
        <NavLink to="/">FYLEY</NavLink>
      </div>
      <NavMenu />
      <div className={styles.clear} />
    </header>
  );
};
