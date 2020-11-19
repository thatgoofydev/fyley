import React, { FC } from "react";
import "./Icon.scss";

export type IconType = "add" | "warning" | "arrow-left" | "arrow-right" | "edit";

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
      case "arrow-left":
        return <path d="M16.7 0l2.8 2.8-9.3 9.2 9.3 9.2-2.8 2.8L4.5 12z" />;
      case "arrow-right":
        return <path d="M5 3l3-3 12 12L8 24l-3-3 9-9z" />;
      case "edit":
        return (
          <path d="M18.4 8.5l1.4 1.4L7.1 22.6 0 24l1.4-7.1L14.1 4.2l1.4 1.4L3.3 18l-.7 3.5 3.5-.7L18.4 8.5zm0-8.5l-3 2.8 5.8 5.7L24 5.7 18.3 0zM6 18.7L17.3 7.4l-.7-.7L5.3 18l.7.7z" />
        );
    }
  };

  return (
    <div className="icon" style={{ width: `${size}px`, height: `${size}px` }}>
      <svg xmlns="http://www.w3.org/2000/svg" width={size} height={size} viewBox={`0 0 24 24`}>
        {renderSwitch()}
      </svg>
    </div>
  );
};
