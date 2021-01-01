import React, { FunctionComponent, useEffect, useRef, useState } from "react";
import { FinancialHeaderNavItem } from "@fyley/financial";
import styles from "./Header.module.scss";

enum NavOptions {
  FINANCIAL = "financial",
  DOCUMENTS = "documents"
}

function useNavState() {
  const [currentMenu, setState] = useState<NavOptions>();
  const navRef = useRef<HTMLElement>(null);

  const handleChange = (menu: NavOptions): void => {
    if (currentMenu === menu) {
      setState(undefined);
    } else {
      setState(menu);
    }
  };

  const closeNav = (): void => {
    setState(undefined);
  };

  useEffect(() => {
    const handleClickOutside = (event: MouseEvent) => {
      if (navRef.current && !navRef.current.contains(event.target as any)) {
        closeNav();
      }
    };

    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, [navRef]);

  return {
    menu: currentMenu,
    handleChange,
    closeNav,
    navRef
  };
}

export const Header: FunctionComponent = () => {
  const { menu, handleChange, navRef } = useNavState();

  return (
    <header className={styles.header}>
      <div>
        <h1>FYLEY</h1>
      </div>
      <nav ref={navRef}>
        <ul>
          <FinancialHeaderNavItem
            baseRoute="/financial"
            open={menu === NavOptions.FINANCIAL}
            onItemClicked={() => handleChange(NavOptions.FINANCIAL)}
          />
          {/*<NavMenuItem item={financialNavMenu} />*/}
          {/*<NavMenuItem item={{ label: "Documents" }} />*/}
          {/*<NavMenuItem item={{ label: "People" }} />*/}
        </ul>
      </nav>
      <div />
    </header>
  );
};
