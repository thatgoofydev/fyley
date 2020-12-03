import React, { FunctionComponent } from "react";
import { Loader } from "../../Loader";

import styles from "./PageLoader.module.scss";

export const PageLoader: FunctionComponent = () => {
  return (
    <div className={styles.pageLoader}>
      <Loader />
    </div>
  );
};
