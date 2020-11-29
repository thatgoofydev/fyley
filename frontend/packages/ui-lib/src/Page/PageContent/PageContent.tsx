import React, { FunctionComponent } from "react";
import styles from "./PageContent.module.scss";

export const PageContent: FunctionComponent = ({ children }) => {
  return <div className={styles.pageContent}>{children}</div>;
};
