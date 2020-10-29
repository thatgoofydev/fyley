import React, { FunctionComponent } from "react";
import { useFetchDossier } from "../helpers/api/useFetchDossier";
import { Field, Form, FormValues, Loader } from "@fyley/ui-lib";
import { createDossier } from "../helpers/api/createDossier";

interface IProps {
  id?: string;
  onSubmit?: () => void;
}

export const DossiersForm: FunctionComponent<IProps> = ({ id, onSubmit }) => {
  const { data, loading } = useFetchDossier(id);

  if (loading) {
    return <Loader />;
  }

  const handleSubmit = async (values: FormValues) => {
    const response = await createDossier({ name: values.name });

    if (!response.ok) {
      console.error("fuck"); // TODO handle property
      return;
    }

    if (onSubmit) {
      onSubmit();
    }
  };

  const handleValidate = (values: FormValues) => {
    const errors: any = {};

    if (!values.name) {
      errors.name = "Name is required!";
    }

    if (values.name && values.name.length < 3) {
      errors.name = "Name is to short. (min. 3 characters)";
    }

    return errors;
  };

  return (
    <>
      <Form
        onSubmit={handleSubmit}
        onValidate={handleValidate}
        initialValues={data.dossier}
      >
        <Field type="text" name="name" label="Name" />
        <button type="submit">Create dossier</button>
      </Form>
    </>
  );
};
