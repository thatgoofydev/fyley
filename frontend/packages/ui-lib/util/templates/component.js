module.exports = (componentName) => ({
  content: `import React, { FunctionComponent } from "react";
import "./${componentName}.scss";

export interface ${componentName}Props {
  foo: string;
};

export const ${componentName}: FunctionComponent<${componentName}Props> = ({ foo }) => (
    <div data-testid="${componentName}" className="foo-bar">{foo}</div>
);

`,
  extension: `.tsx`,
});
