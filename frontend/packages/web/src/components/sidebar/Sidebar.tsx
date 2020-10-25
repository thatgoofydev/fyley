import React, { FunctionComponent } from "react";
// @ts-ignore
import styled from "styled-components";

const SidebarWrapper = styled.div`
  background-color: #363740;
  height: 100vh;
`;

export const Sidebar: FunctionComponent = () => {
  return (
    <>
      <SidebarWrapper>Sidebar</SidebarWrapper>
    </>
  );
};
