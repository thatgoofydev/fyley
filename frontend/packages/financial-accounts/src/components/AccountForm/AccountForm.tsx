import React, { FunctionComponent } from "react";
import { Button, Field, Form, FormActions, FormControl, FormValues } from "@fyley/ui-lib";
import { AccountFormViewModel, AccountNumberType } from "../../helpers/api/defineAccount";

interface IAccountFormProps {
  id?: string;
  account: AccountFormViewModel;
  onSubmit: (values: AccountFormViewModel) => Promise<boolean>;
  onSubmitted?: () => void;
}

export const AccountForm: FunctionComponent<IAccountFormProps> = ({
  id,
  account,
  onSubmit,
  onSubmitted
}) => {
  const handleValidate = (values: FormValues) => {
    const errors: FormValues = {};

    if (!values.name) {
      errors.name = "Name is required";
    }

    if (!values["accountNumber.value"]) {
      errors["accountNumber.value"] = "Account nr. is required";
    }

    return errors;
  };

  const handleSubmit = async (values: FormValues, actions: FormActions) => {
    const result = await onSubmit({
      name: values.name,
      description: values.description,
      accountNumber: {
        type: AccountNumberType.Iban,
        value: values["accountNumber.value"]
      }
    });

    if (!result) {
      return await actions.displayError();
    }
    await actions.displaySuccess();

    if (onSubmitted) onSubmitted();
  };

  return (
    <Form onSubmit={handleSubmit} onValidate={handleValidate} initialValues={account}>
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
