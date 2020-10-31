module.exports = {
  roots: ["src"],
  setupFilesAfterEnv: ["./jest.setup.ts"],
  moduleFileExtensions: ["ts", "js"],
  testPathIgnorePatterns: ["node_modules/"],
  transform: {
    ".(ts|tsx)": "ts-jest"
  },
  testMatch: ["**/*.spec.(ts|tsx)"]
};
