import React, { FunctionComponent, useContext, useState } from "react";

export interface PageTitleContextProps {
  setTitle: (title: string) => void;
  getTitle: () => string;
}

export const PageTitleContext = React.createContext<PageTitleContextProps>({
  getTitle: () => "",
  setTitle: (title: string) => {}
});

export const PageTitleProvider: FunctionComponent = ({ children }) => {
  const [state, setState] = useState("initial-title");
  const getTitle = (): string => state;
  const setTitle = (title: string) => setState(title);

  return (
    <>
      <PageTitleContext.Provider value={{ getTitle, setTitle }}>
        {children}
      </PageTitleContext.Provider>
    </>
  );
};

export const usePageTitle = (): PageTitleContextProps => {
  return useContext(PageTitleContext);
};
