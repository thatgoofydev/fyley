import React from "react";
import { render, cleanup } from "@testing-library/react";
import { MemoryRouter, Route } from "react-router-dom";
import { FinancialContent } from "./FinancialContent";

afterEach(cleanup);

describe("FinancialContent", function () {
  it("should render", function () {
    const { container } = render(
      <MemoryRouter initialEntries={["/financial/overview"]}>
        <Route path="/financial">
          <FinancialContent />
        </Route>
      </MemoryRouter>
    );
    expect(container).toMatchSnapshot();
  });
});
