import { useApi } from "@fyley/utils";

interface FetchFormRequest {
  id: string;
}

interface FetchFormResponse {
  dossier: DossierDto;
}

interface DossierDto {
  id: string;
  name: string;
}

export const useFetchForm = (id?: string) => {
  const url = "/dossiers/fetch-form";
  return useApi<FetchFormResponse, FetchFormRequest>(url, { id: id || "new" });
};
