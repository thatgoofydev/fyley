import { useApi } from "@fyley/utils";

export interface DossiersOverviewResponse {
  dossiers: DossierDto[];
}

export interface DossierDto {
  id: string;
  name: string;
}

export const useDossiersOverview = () => {
  const url = "/dossiers/overview-dossiers";
  return useApi<DossiersOverviewResponse>(url);
};
