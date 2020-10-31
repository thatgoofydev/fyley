interface SubmitDossierRequest {
  id?: string;
  name: string;
}

interface SubmitDossierResponse {
  id: string;
}

interface SubmitDossierReturn {
  ok: boolean;
  result?: SubmitDossierResponse;
}

export const submitDossierForm = async (
  request: SubmitDossierRequest
): Promise<SubmitDossierReturn> => {
  const url = "https://localhost:5001/bff/desktop/dossiers/submit-form";

  // TODO move to util
  const response = await fetch(url, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json;charset=utf-8"
    },
    body: JSON.stringify(request)
  });

  if (!response.ok) {
    return {
      ok: false
    };
  }

  const result: SubmitDossierResponse = await response.json();
  return {
    ok: true,
    result
  };
};
