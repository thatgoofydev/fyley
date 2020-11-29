import React, { FunctionComponent, useState } from "react";
import styles from "./PageError.module.scss";

export interface IPageErrorProps {
  backLink?: string;
  details?: string;
}

export const PageError: FunctionComponent<IPageErrorProps> = ({ backLink, details }) => {
  const [showDetails, setDetailsVisible] = useState(false);

  const toggleDetails = () => setDetailsVisible(old => !old);

  return (
    <div className={styles.pageError}>
      <h1>Oops!</h1>
      <h2>Looks like something went wrong...</h2>
      <div className={styles.whatNext}>
        <p>What now?</p>
        <ul>
          <li>
            {backLink && (
              <>
                Go <a href={backLink}>back</a> and try again later.
              </>
            )}
            {!backLink && "Try again later."}
          </li>
          <li>Contact the application administrator.</li>
        </ul>
      </div>
      {details && (
        <div className={styles.details}>
          <button data-testid="error-toggle" onClick={toggleDetails}>
            {showDetails ? "Hide" : "Show"} details
          </button>
          {showDetails && <p>{details}</p>}
        </div>
      )}
    </div>
  );
};
