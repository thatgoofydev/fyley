module.exports = (componentName) => ({
  content: `import React from "react";
import { Meta, Story } from '@storybook/react';
import { ${componentName}, ${componentName}Props } from "./${componentName}";

export default {
    title: "General/${componentName}",
    component: ${componentName}
} as Meta;

const Template: Story<${componentName}Props> = (args) => <${componentName} {...args} />;

export const WithBar = Template.bind({});
WithBar.args = {
  foo: "bar"
};

export const WithBaz = Template.bind({});
WithBaz.args = {
  foo: "baz"
};
`,
  extension: `.stories.tsx`,
});
