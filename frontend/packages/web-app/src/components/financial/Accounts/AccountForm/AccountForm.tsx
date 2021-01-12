import React from "react";
import { Button, Field, Form, FormActions, FormControl, FormErrors } from "@fyley/ui-lib";
import { AccountNumberType } from "../AccountNew/defineAccount";

interface IAccountFormProps<T extends IFormData> {
  id?: string;
  data: T;
  onSubmit: (values: T) => Promise<boolean>;
  onSubmitted?: () => void;
}

interface IFormData {
  name: string;
  description: string;
  accountNumber: IAccountNumFormData;
}

interface IAccountNumFormData {
  type: AccountNumberType;
  value: string;
}

export const AccountForm = <T extends IFormData>({
  id,
  data,
  onSubmit,
  onSubmitted
}: IAccountFormProps<T>) => {
  const handleSubmit = async (values: T, actions: FormActions) => {
    const result = await onSubmit({
      name: values.name,
      description: values.description,
      accountNumber: {
        type: AccountNumberType.Iban,
        value: (values as any)["accountNumber.value"]
      }
    } as T);

    if (!result) {
      return await actions.displayError();
    }
    await actions.displaySuccess();

    if (onSubmitted) onSubmitted();
  };

  const handleValidate = (values: T) => {
    const errors: FormErrors<T> = {};

    if (!values.name) {
      errors.name = "Name is required";
    }

    return errors;
  };

  return (
    <Form initialValues={data} onSubmit={handleSubmit} onValidate={handleValidate}>
      <Field name="name" label="Name" placeholder="Ex. Savings" />
      <Field
        name="description"
        label="Description"
        placeholder="Ex. Just trying to save some money"
      />
      <Field name="accountNumber.value" label="Account Nr." placeholder="Ex. BE68 9535 7828 1734" />
      <FormControl>
        <Button label={id ? "Save" : "Create"} type="submit" />
      </FormControl>
    </Form>
  );
};
