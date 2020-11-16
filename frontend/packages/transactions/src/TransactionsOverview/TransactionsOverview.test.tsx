import React from "react";
import { render, screen } from "@testing-library/react";
import { TransactionsOverview } from "./TransactionsOverview";

describe("<TransactionsOverview />", () => {
  test("should render", () => {
    const result = render(<TransactionsOverview />);
    expect(result).toMatchSnapshot();
  });
});
