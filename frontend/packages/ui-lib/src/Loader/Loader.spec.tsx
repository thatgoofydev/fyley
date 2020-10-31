import React from "react";
import { render, cleanup } from "@testing-library/react";
import { Loader } from "./Loader";

afterEach(cleanup);

describe("Loader", function () {
  test("should render", () => {
    const rendered = render(<Loader />);
    expect(rendered).toMatchSnapshot();
  });
});
