import { useApi } from "../useApi";

interface ListDossiersResponse {
  dossiers: DossierDto[];
}

interface DossierDto {
  id: string;
  name: string;
}

export const useListDossiers = () => {
  return useApi<ListDossiersResponse>("/bff/dossiers/listdossiers");
};
