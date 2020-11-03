import {IRandomEventResult} from "./randomEventResult.interace";

export interface IProcedureSimResult {
  procedureAlias: string;
  waitingTime: number;
  startTime: number;
  endTime: number;
  duration: number;
  randomEvents: IRandomEventResult[];
}
