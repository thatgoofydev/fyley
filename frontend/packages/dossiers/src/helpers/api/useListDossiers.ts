import { useApi } from "../useApi";

export interface ListDossiersResponse {
  dossiers: DossierDto[];
}

export interface DossierDto {
  id: string;
  name: string;
}

export const useListDossiers = () => {
  return useApi<ListDossiersResponse>("/bff/dossiers/listdossiers");
};
