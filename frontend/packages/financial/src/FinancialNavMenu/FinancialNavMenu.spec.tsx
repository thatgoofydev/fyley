import React from "react";
import { render, cleanup } from "@testing-library/react";
import { FinancialHeaderNavItem, IFinancialHeaderNavProps } from "./FinancialNavMenu";
import { MemoryRouter } from "react-router-dom";

const noop = () => {};
const defaultProps: IFinancialHeaderNavProps = {
  open: true,
  baseRoute: "/financial",
  onItemClicked: noop
};

afterEach(cleanup);

describe("FinancialNavMenu", function () {
  it("should render", function () {
    const { container } = render(
      <MemoryRouter>
        <FinancialHeaderNavItem {...defaultProps} />
      </MemoryRouter>
    );
    expect(container).toMatchSnapshot();
  });

  it("should add class to active route", function () {
    const { container } = render(
      <MemoryRouter initialEntries={["/financial/overview"]}>
        <FinancialHeaderNavItem {...defaultProps} />
      </MemoryRouter>
    );
    expect(container).toMatchSnapshot();
  });
});
