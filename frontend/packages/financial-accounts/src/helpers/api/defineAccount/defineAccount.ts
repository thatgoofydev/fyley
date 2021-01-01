import { AccountFormViewModel } from "./models";

export const defineAccount = async (model: AccountFormViewModel): Promise<boolean> => {
  const result = await fetch(`https://localhost:5001/bff/accounts/submit_define_account_form`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(model)
  });

  return result.ok;
};
