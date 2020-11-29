import React from "react";
import { render, cleanup } from "@testing-library/react";
import { PageContent } from "./PageContent";

afterEach(cleanup);

describe("PageContent", function () {
  it("should render", function () {
    const { container, getByText } = render(
      <PageContent>
        <p>Some content</p>
      </PageContent>
    );

    expect(getByText("Some content")).not.toBeNull();
    expect(container).toMatchSnapshot();
  });
});
