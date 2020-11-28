import React, { FunctionComponent } from "react";
import styles from "./Page.module.scss";

export interface IPageProps {
  title: string;
}

export const Page: FunctionComponent<IPageProps> = ({ title, children }) => {
  return (
    <div className={styles.pageContainer}>
      <header className={styles.pageHeader}>
        <h1>{title}</h1>
      </header>
      <div className={styles.pageContent}>{children}</div>
    </div>
  );
};
