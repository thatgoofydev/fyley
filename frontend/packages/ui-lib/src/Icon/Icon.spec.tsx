import React from "react";
import { render, cleanup } from "@testing-library/react";

import { Icon } from "./Icon";

afterEach(cleanup);

describe("<Icon />", () => {
  test("should render icon at default of size 24", () => {
    const rendered = render(<Icon type="add" />);
    const iconWrapper = rendered.container.firstChild;
    expect(iconWrapper).toHaveStyle("width: 24px; height: 24px;");
    expect(iconWrapper).toHaveClass("icon");
  });

  test("should render icon at correct size when a custom size is provided", () => {
    const rendered = render(<Icon type="add" size={200} />);
    const iconWrapper = rendered.container.firstChild;
    expect(iconWrapper).toHaveStyle("width: 200px; height: 200px;");
    expect(iconWrapper).toHaveClass("icon");
  });
});

describe('<Icon type="add" />', () => {
  test("should render add icon", () => {
    const rendered = render(<Icon type="add" />);
    expect(rendered).toMatchSnapshot();
  });
});

describe('<Icon type="warning" />', () => {
  test("should render warning icon", () => {
    const rendered = render(<Icon type="warning" />);
    expect(rendered).toMatchSnapshot();
  });
});
