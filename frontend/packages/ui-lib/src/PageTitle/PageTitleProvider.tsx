import React, { FunctionComponent, useState } from "react";

interface IProps {
  title: string;
  setTitle: (title: string) => void;
}

export const PageTitleContext = React.createContext<IProps>({
  title: "Fyley",
  setTitle: () => {}
});

export const PageTitleProvider: FunctionComponent = ({ children }) => {
  const [title, setTitle] = useState("Fyley");

  const context = {
    title,
    setTitle
  };
  return (
    <>
      <PageTitleContext.Provider value={context}>{children}</PageTitleContext.Provider>
    </>
  );
};
