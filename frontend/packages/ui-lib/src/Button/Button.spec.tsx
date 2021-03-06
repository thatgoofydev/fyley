import React from "react";
import { render, cleanup } from "@testing-library/react";
import { Button, ButtonProps } from "./Button";

const noop = () => {};
const defaultProps: ButtonProps = {
  label: "Button",
  type: "button",
  disabled: false,
  onClick: noop
};

afterEach(cleanup);

describe("Button", function () {
  describe("should render correctly", function () {
    it("when default", function () {
      const { container } = render(<Button {...defaultProps} />);
      expect(container).toMatchSnapshot();
    });

    it("when disabled", function () {
      const props: ButtonProps = {
        ...defaultProps,
        disabled: true
      };
      const { container } = render(<Button {...props} />);
      expect(container).toMatchSnapshot();
    });

    // TODO add tests with form to check submit feedback
  });

  it("should trigger onClick", function () {
    const onClickCallback = jest.fn();

    const props: ButtonProps = {
      ...defaultProps,
      onClick: onClickCallback,
      "data-testid": "btn"
    };

    const { getByTestId } = render(<Button {...props} />);
    getByTestId("btn").click();

    expect(onClickCallback).toHaveBeenCalledTimes(1);
  });
});
