import React, { FC } from "react";
import ReactDom from "react-dom";

const Example: FC = () => {
  return <main>content</main>;
};

ReactDom.render(<Example />, document.getElementById("root"));
