import {IRandomEventHistory} from "./randomEventHistory.interface";

export interface IProcedureHistory {
  procedureHistoryId: number;
  procedureName: string;
  procedureAlias: string;
  startTime: number;
  endTime: number;
  waitingTime: number;
  randomEvents: IRandomEventHistory[];
}
