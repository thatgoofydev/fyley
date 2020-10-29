import { ApiResult, useApi } from "../useApi";

interface FetchDossierRequest {
  id: string;
}

interface FetchDossierResponse {
  dossier: DossierDto;
}

interface DossierDto {
  id: string;
  name: string;
}

export const useFetchDossier = (
  id?: string
): ApiResult<FetchDossierResponse> => {
  if (!id) {
    return {
      loading: false,
      data: {
        dossier: {
          name: ""
        }
      }
    };
  }
  const request: FetchDossierRequest = { id };
  return useApi<FetchDossierResponse>("/bff/dossiers/fetchDossier", request);
};
