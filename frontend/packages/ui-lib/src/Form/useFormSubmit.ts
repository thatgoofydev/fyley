import { useContext } from "react";
import { FormContext } from "./FormContext";
import { SubmitStatus } from "./types";

interface FormSubmitActions {
  inFormContext: boolean;
  status: SubmitStatus;
}

export const useFormSubmit = (): FormSubmitActions => {
  const context = useContext(FormContext);

  if (!context) {
    return {
      inFormContext: false,
      status: SubmitStatus.IDLE
    };
  }

  return {
    inFormContext: true,
    status: context.state.submitStatus
  };
};
