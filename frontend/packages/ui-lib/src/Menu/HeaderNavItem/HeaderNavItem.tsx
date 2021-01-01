import React, { FunctionComponent } from "react";
import classNames from "classnames";

import styles from "./HeaderNavItem.module.scss";

interface IHeaderNavItemProps {
  label: string;
  open?: boolean;
  active?: boolean;
  onItemClicked: () => void;
  onClick?: () => void;
  children?: React.ReactElement<IHeaderNavItemProps>[] | React.ReactElement<IHeaderNavItemProps>;
}

export const HeaderNavItem: FunctionComponent<IHeaderNavItemProps> = ({
  label,
  open = false,
  active = false,
  onItemClicked,
  onClick,
  children
}) => {
  const handleClick = () => {
    if (onClick) onClick();
    onItemClicked();
  };

  const labelStyles = classNames({
    [styles.labelWithSub]: children,
    [styles.active]: active
  });

  const renderLabel = () => {
    if (!onClick)
      return (
        <span className={labelStyles} onClick={handleClick}>
          {label}
        </span>
      );
    return (
      <a className={labelStyles} onClick={handleClick}>
        {label}
      </a>
    );
  };

  const navStyles = classNames(styles.navItem, {
    [styles.open]: open
  });
  return (
    <li className={navStyles}>
      {renderLabel()}
      {open && children && <ul className={styles.subNav}>{children}</ul>}
    </li>
  );
};
