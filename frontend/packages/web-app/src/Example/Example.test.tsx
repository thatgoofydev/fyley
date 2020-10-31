import React from "react";
import { render, screen } from "@testing-library/react";

import { Example } from "./Example";

describe("<Example />", () => {
  test("should render 'Example Text'", () => {
    render(<Example />);
    expect(screen.getByText("Example Text")).toBeDefined();
  });
});
