import React, { FunctionComponent } from "react";
import "./Icon.scss";

export type IconType = "add" | "edit";

export interface IconProps {
  type: IconType;
  size?: number;
}

export const Icon: FunctionComponent<IconProps> = ({ type, size = 24 }) => {
  const renderAdd = () => (
    <path d="M12 2a10 10 0 110 20 10 10 0 010-20zm0-2a12 12 0 100 24 12 12 0 000-24zm6 13h-5v5h-2v-5H6v-2h5V6h2v5h5v2z" />
  );

  const renderEdit = () => (
    <path d="M18.363 8.464l1.433 1.431-12.67 12.669L.001 24l1.439-7.127L14.105 4.205l1.431 1.431L3.281 17.86l-.726 3.584 3.584-.723L18.363 8.464zM18.307 0l-2.815 2.817 5.691 5.692L24 5.688 18.307 0zM5.989 18.718L17.302 7.402l-.705-.707L5.284 18.009l.705.709z" />
  );

  const renderSwitch = () => {
    switch (type) {
      case "add":
        return renderAdd();
      case "edit":
        return renderEdit();
    }
  };

  return (
    <div className="icon" style={{ width: `${size}px`, height: `${size}px` }}>
      <svg
        xmlns="http://www.w3.org/2000/svg"
        width={size}
        height={size}
        viewBox={`0 0 24 24`}
      >
        {renderSwitch()}
      </svg>
    </div>
  );
};
