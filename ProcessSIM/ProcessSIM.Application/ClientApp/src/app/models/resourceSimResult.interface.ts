export interface IResourceSimResult {
  resourceName: string;
  activeTime: IActiveTimeItem[];
  cost: number;
  useTime: number;
  downtime: number;
}

interface IActiveTimeItem {
  from: number;
  to: number;
}
