import {IResourceUseHistory} from "./resourceUseHistory";

export interface IResourceHistory {
  resourceHistoryId: number;
  resourceName: string;
  resourceId: number;
  useTime: number;
  downtime: number;
  cost: number;
  useHistory: IResourceUseHistory;
}
