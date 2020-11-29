import React from "react";
import { render, cleanup } from "@testing-library/react";
import { Button, IButtonProps } from "./Button";

const noop = () => {};
const defaultProps: IButtonProps = {
  label: "Button",
  style: "primary",
  type: "button",
  size: "normal",
  color: "blue",
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

    it("when small size", function () {
      const props: IButtonProps = {
        ...defaultProps,
        size: "small"
      };
      const { container } = render(<Button {...props} />);
      expect(container).toMatchSnapshot();
    });

    it("when disabled", function () {
      const props: IButtonProps = {
        ...defaultProps,
        disabled: true
      };
      const { container } = render(<Button {...props} />);
      expect(container).toMatchSnapshot();
    });

    it("when secondary style", function () {
      const props: IButtonProps = {
        ...defaultProps,
        style: "secondary"
      };
      const { container } = render(<Button {...props} />);
      expect(container).toMatchSnapshot();
    });

    // TODO add tests with form to check submit feedback
  });

  it("should trigger onClick", function () {
    const onClickCallback = jest.fn();

    const props: IButtonProps = {
      ...defaultProps,
      onClick: onClickCallback,
      "data-testid": "btn"
    };

    const { getByTestId } = render(<Button {...props} />);
    getByTestId("btn").click();

    expect(onClickCallback).toHaveBeenCalledTimes(1);
  });
});
