import React, { FC } from "react";
import styles from "./Icon.module.scss";

export type IconType = "add" | "warning";

export interface IProps {
  type: IconType;
  size?: number;
}

export const Icon: FC<IProps> = ({ type, size = 24 }) => {
  const renderSwitch = () => {
    switch (type) {
      case "add":
        return (
          <path d="M12 2a10 10 0 110 20 10 10 0 010-20zm0-2a12 12 0 100 24 12 12 0 000-24zm6 13h-5v5h-2v-5H6v-2h5V6h2v5h5v2z" />
        );
      case "warning":
        return (
          <path d="M12 5l9 16H3l9-16zm0-4L0 23h24L12 1zm-1 9h2v6h-2v-6zm1 10a1 1 0 110-3 1 1 0 010 3z" />
        );
    }
  };

  return (
    <div className={styles.icon} style={{ width: `${size}px`, height: `${size}px` }}>
      <svg xmlns="http://www.w3.org/2000/svg" width={size} height={size} viewBox={`0 0 24 24`}>
        {renderSwitch()}
      </svg>
    </div>
  );
};
