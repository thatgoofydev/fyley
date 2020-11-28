import React, { useEffect, useRef, useState } from "react";
import { Switch, Route, useLocation } from "react-router-dom";

import styles from "./App.module.scss";
import { FinancialContent, FinancialNavMenu } from "@fyley/financial";

enum NavMenu {
  FINANCIAL,
  DOCUMENTS
}

function useNavState() {
  const [currentMenu, setState] = useState<NavMenu>();
  const navRef = useRef<HTMLElement>(null);

  const handleChange = (menu: NavMenu): void => {
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
        setState(undefined);
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

function App() {
  const { pathname } = useLocation();
  const { menu, handleChange, closeNav, navRef } = useNavState();

  const getRootNavStyle = (path: string) => {
    return pathname.startsWith(`/${path}`) ? styles.active : undefined;
  };

  return (
    <>
      <header className={styles.header}>
        <div>
          <h1>FYLEY</h1>
        </div>
        <nav ref={navRef}>
          <ul>
            <li>
              <span
                className={getRootNavStyle("financial")}
                onClick={() => handleChange(NavMenu.FINANCIAL)}
              >
                Financial
              </span>
              <FinancialNavMenu
                isOpen={menu === NavMenu.FINANCIAL}
                baseRoute="/financial"
                onClick={closeNav}
              />
            </li>
            {/*<li>*/}
            {/*  <span*/}
            {/*    className={getRootNavStyle("documents")}*/}
            {/*    onClick={() => handleChange(NavMenu.DOCUMENTS)}*/}
            {/*  >*/}
            {/*    Documents*/}
            {/*  </span>*/}
            {/*  {menu === NavMenu.DOCUMENTS && (*/}
            {/*    <ul>*/}
            {/*      <li>*/}
            {/*        <NavLink to="/documents/overview">Overview</NavLink>*/}
            {/*      </li>*/}
            {/*      <li>*/}
            {/*        <NavLink to="/documents/something">Something</NavLink>*/}
            {/*      </li>*/}
            {/*    </ul>*/}
            {/*  )}*/}
            {/*</li>*/}
          </ul>
        </nav>
        <div />
      </header>

      <Switch>
        <Route path="/financial" component={FinancialContent} />
      </Switch>
    </>
  );
}

export default App;
