import React, { FunctionComponent } from "react";
import { NavLink, useLocation } from "react-router-dom";
import styles from "./NavItem.module.scss";
import classNames from "classnames";

interface INavItemBase {
  label: string;
  onClick?: () => void;
}

interface INavGroupItemProps extends INavItemBase {
  route?: never;
  baseRoute: string;
  children: INavItemProps[];
  open?: boolean;
}

interface INavItemRouteProps extends INavItemBase {
  route: string;
  baseRoute?: never;
  children?: never;
  open?: never;
}

type INavItemProps = INavGroupItemProps | INavItemRouteProps;

export const NavItem: FunctionComponent<INavItemProps> = ({
  label,
  onClick,
  baseRoute,
  route,
  children,
  open
}) => {
  const { pathname } = useLocation();

  const labelStyles = classNames({
    [styles.active]: pathname.startsWith(baseRoute! || route!)
  });

  const getChildProps = (child: INavItemProps): INavItemProps => {
    if (child.route) {
      return {
        ...child,
        route: baseRoute + child.route
      };
    } else {
      return {
        ...child,
        baseRoute: baseRoute! + child.baseRoute!
      } as INavGroupItemProps;
    }
  };

  const renderHeader = () => {
    if (route) {
      return (
        <NavLink onClick={onClick} className={labelStyles} to={route}>
          {label}
        </NavLink>
      );
    } else {
      return (
        <span onClick={onClick} className={labelStyles}>
          {label}
        </span>
      );
    }
  };

  return (
    <li className={styles.navItem}>
      {renderHeader()}

      {children && open && (
        <ul className={styles.subNav}>
          {children.map(child => (
            <NavItem
              key={child.baseRoute || child.route}
              {...getChildProps(child)}
              onClick={onClick}
              // baseRoute={child.baseRoute ? baseRoute + "/" + child.baseRoute : undefined}
              // route={child.route ? baseRoute + "/" + child.route : undefined}
            />
          ))}
        </ul>
      )}
    </li>
  );
};
