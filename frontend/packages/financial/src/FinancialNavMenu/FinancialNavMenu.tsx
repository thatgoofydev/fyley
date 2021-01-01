import React, { FunctionComponent, useState } from "react";
import { useHistory, useLocation } from "react-router-dom";
import { HeaderNavItem } from "@fyley/ui-lib";

enum FinancialNavOptions {
  Overview = "overview",
  Accounts = "accounts"
}

const useFinancialNav = (baseRoute: string, onItemClicked: () => void) => {
  const [currentOption, setOption] = useState<FinancialNavOptions>();
  const history = useHistory();
  const location = useLocation();

  const navigateTo = (route: FinancialNavOptions) => {
    history.push(`${baseRoute}/${route.toString()}`);
    onItemClicked();
    setOption(route);
  };

  const isActive = location.pathname.startsWith(baseRoute);

  return {
    currentOption,
    isActive,
    navigateTo
  };
};

interface IFinancialHeaderNavProps {
  baseRoute: string;
  open: boolean;
  onItemClicked: () => void;
}

export const FinancialHeaderNavItem: FunctionComponent<IFinancialHeaderNavProps> = ({
  baseRoute,
  open,
  onItemClicked
}) => {
  const { currentOption, isActive, navigateTo } = useFinancialNav(baseRoute, onItemClicked);
  const history = useHistory();
  const location = useLocation();

  const navigateToOverview = () => navigateTo(FinancialNavOptions.Overview);
  const navigateToAccounts = () => navigateTo(FinancialNavOptions.Accounts);

  return (
    <HeaderNavItem open={open} active={isActive} label="Financial" onItemClicked={onItemClicked}>
      <HeaderNavItem
        label={FinancialNavOptions.Overview}
        active={currentOption === FinancialNavOptions.Overview}
        onItemClicked={() => navigateTo(FinancialNavOptions.Overview)}
      />
      <HeaderNavItem
        label={FinancialNavOptions.Accounts}
        active={currentOption === FinancialNavOptions.Accounts}
        onItemClicked={() => navigateTo(FinancialNavOptions.Accounts)}
      />
    </HeaderNavItem>
  );
};
