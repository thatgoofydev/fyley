import { useState } from "react";

interface CreateDossierRequest {
  name: string;
}

interface CreateDossierResponse {
  id: string;
}

interface CreateDossierReturn {
  ok: boolean;
  result: CreateDossierResponse;
}

export const createDossier = async (
  request: CreateDossierRequest
): Promise<CreateDossierReturn> => {
  const url = "/bff/dossiers/createDossier";
  const response = await fetch(`https://localhost:5001${url}`, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json;charset=utf-8"
    },
    body: JSON.stringify(request)
  });

  if (!response.ok) {
    return { ok: false } as CreateDossierReturn;
  }

  const result: CreateDossierResponse = await response.json();
  return {
    ok: true,
    result
  };
};
