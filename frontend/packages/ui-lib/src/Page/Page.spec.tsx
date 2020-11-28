import React from "react";
import { render, cleanup } from "@testing-library/react";
import { Page } from "./Page";

describe("Page", function () {
  it("should render", function () {
    const { container, getByText } = render(
      <Page title={"Page title"}>
        <p>Some content</p>
      </Page>
    );

    expect(getByText("Page title")).not.toBeNull();
    expect(getByText("Some content")).not.toBeNull();
    expect(container).toMatchSnapshot();
  });
});
