import React from "react";
import { render, cleanup } from "@testing-library/react";
import { LinkButton } from "./LinkButton";

afterEach(cleanup);

describe("<LinkButton />", function () {
  test("should render text", () => {
    const rendered = render(<LinkButton text="test-button" />);
    expect(rendered).toMatchSnapshot();
  });

  test("should render icon", () => {
    const rendered = render(<LinkButton icon="add" text="test-button" />);
    expect(rendered).toMatchSnapshot();
  });

  test("should render a tag when a link has been defined", () => {
    render(<LinkButton href="http://google.com" text="test-button" />);

    const link = document.getElementsByTagName("a");
    expect(link).toBeDefined();
  });
});
