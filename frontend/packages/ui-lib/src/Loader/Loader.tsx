import React, { FunctionComponent } from "react";
import styles from "./Loader.module.scss";
import { PageContent } from "../Page";

export const Loader: FunctionComponent = () => {
  return <div className={styles.loader} />;
};
