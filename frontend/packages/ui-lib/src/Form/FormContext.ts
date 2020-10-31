import { createContext } from "react";
import { IFieldState, IFormState } from "./types";

export interface IFormContext {
  setValue: (name: string, value: string) => void;
  getField: (name: string) => IFieldState;
  handleFocus: (name: string) => void;
  handleBlur: (name: string) => void;
}

export type FormContextType = (IFormContext & IFormState) | null;

export const FormContext = createContext<FormContextType>(null);
