import { IAccountFormModel } from "./models";

export const submitAccount = async (id: string, model: IAccountFormModel): Promise<boolean> => {
  const result = await fetch(`https://localhost:5001/bff/desktop/accounts/submit/${id}`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(model)
  });

  return result.ok;
};
