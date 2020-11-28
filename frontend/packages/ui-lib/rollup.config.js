import typescript from "rollup-plugin-typescript2";
import pkg from "./package.json";
import postcss from "rollup-plugin-postcss";

const input = "src/index.ts";

const plugins = [
  typescript({
    typescript: require("typescript")
  }),
  postcss({
    sourceMap: true,
    minimize: false
  })
];

const external = [
  ...Object.keys(pkg.dependencies || {}),
  ...Object.keys(pkg.peerDependencies || {})
];

export default {
  input,
  plugins,
  external,

  output: [
    {
      file: pkg.main,
      format: "cjs",
      sourcemap: true
    },
    {
      file: pkg.module,
      format: "esm",
      sourcemap: true
    }
  ]
};
