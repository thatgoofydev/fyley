import React from "react";
import { render, cleanup } from "@testing-library/react";
import { FormControl } from "./FormControl";

afterEach(cleanup);

describe("FormControl", function () {
  it("should render children", function () {
    const { container, getByText } = render(<FormControl>some text</FormControl>);

    expect(getByText("some text")).not.toBeNull();
    expect(container).toMatchSnapshot();
  });
});
