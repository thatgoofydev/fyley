import React, { FunctionComponent } from "react";
import { Button, Field, Form, FormActions, FormControl, FormValues } from "@fyley/ui-lib";
import { AccountNumberType, IAccountFormModel } from "../../helpers/api/submitAccount/models";
import { submitAccount } from "../../helpers/api/submitAccount/submitAccount";

interface IAccountFormProps {
  id?: string;
  account: IAccountFormModel;
  onSubmitted: () => void;
}

export const AccountForm: FunctionComponent<IAccountFormProps> = ({ id, account, onSubmitted }) => {
  const handleValidate = (values: FormValues) => {
    const errors: FormValues = {};

    if (!values.name) {
      errors.name = "Name is required";
    }

    if (!values.accountNumber) {
      errors.accountNumber = "Account nr. is required";
    }

    return errors;
  };

  const handleSubmit = async (values: FormValues, actions: FormActions) => {
    const result = await submitAccount(id || "new", {
      ...(values as IAccountFormModel),
      accountNumberType: AccountNumberType.IBAN
    });

    if (!result) {
      return await actions.displayError();
    }

    await actions.displaySuccess();
    onSubmitted();
  };

  return (
    <Form onSubmit={handleSubmit} onValidate={handleValidate} initialValues={account}>
      <Field name="name" label="Name" placeholder="Ex. Savings" />
      <Field
        name="description"
        label="Description"
        placeholder="Ex. Just trying to save some money"
      />
      <Field name="accountNumber" label="Account Nr." placeholder="Ex. BE68 9535 7828 1734" />
      <FormControl>
        <Button label={id ? "Save" : "Create"} type="submit" />
      </FormControl>
    </Form>
  );
};
