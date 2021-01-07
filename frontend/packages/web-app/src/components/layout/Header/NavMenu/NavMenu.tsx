import React, { FunctionComponent, useEffect, useRef, useState } from "react";
import { NavItem } from "./NavItem/NavItem";
import styles from "./NavMenu.module.scss";

enum NavOptions {
  FINANCIAL = "financial",
  DOCUMENTS = "documents"
}

const financialNavItems = [
  {
    label: "Overview",
    route: "/overview"
  },
  {
    label: "Accounts",
    route: "/accounts"
  }
];

const useNavMenuState = () => {
  const [currentMenu, setMenu] = useState<NavOptions>();
  const navRef = useRef<HTMLElement>(null);

  useEffect(() => {
    const handleClickOutside = (event: MouseEvent) => {
      if (navRef.current && !navRef.current.contains(event.target as any)) {
        closeNav();
      }
    };

    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, [navRef]);

  const isOpen = (menu: NavOptions): boolean => {
    return currentMenu === menu;
  };

  const open = (menu: NavOptions): (() => void) => {
    return () => {
      setMenu(prevState => (prevState === menu ? undefined : menu));
    };
  };

  const closeNav = (): void => {
    setMenu(undefined);
  };

  return {
    isOpen,
    open,
    navRef
  };
};

export const NavMenu: FunctionComponent = () => {
  const { isOpen, open, navRef } = useNavMenuState();

  return (
    <nav className={styles.nav} ref={navRef}>
      <ul>
        <NavItem
          open={isOpen(NavOptions.FINANCIAL)}
          onClick={open(NavOptions.FINANCIAL)}
          label="Financial"
          baseRoute="/financial"
          children={financialNavItems}
        />
        {/*<NavItem label="Documents" route="/documents" />*/}
      </ul>
    </nav>
  );
};
