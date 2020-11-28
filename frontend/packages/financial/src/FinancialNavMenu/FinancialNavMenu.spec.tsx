import React from "react";
import { render, cleanup } from "@testing-library/react";
import { FinancialNavMenu, IFinancialNavMenuProps } from "./FinancialNavMenu";
import { MemoryRouter } from "react-router-dom";

const noop = () => {};
const defaultProps: IFinancialNavMenuProps = {
  isOpen: true,
  baseRoute: "/financial",
  onClick: noop
};

afterEach(cleanup);

describe("FinancialNavMenu", function () {
  it("should render", function () {
    const { container } = render(
      <MemoryRouter>
        <FinancialNavMenu {...defaultProps} />
      </MemoryRouter>
    );
    expect(container).toMatchSnapshot();
  });

  it("should add class to active route", function () {
    const { container } = render(
      <MemoryRouter initialEntries={["/financial/overview"]}>
        <FinancialNavMenu {...defaultProps} />
      </MemoryRouter>
    );
    expect(container).toMatchSnapshot();
  });
});
