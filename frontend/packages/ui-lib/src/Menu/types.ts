export type Menu = {
  items?: MenuItem[];
};

export type MenuItem = {
  label: string;
  items?: MenuItem[];
  onClick?: () => void;
};
