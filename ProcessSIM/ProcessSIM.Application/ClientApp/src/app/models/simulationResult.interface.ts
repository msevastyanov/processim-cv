import {IProcedureSimResult} from "./procedureSimResult.interface";
import {IResourceSimResult} from "./resourceSimResult.interface";

export interface ISimulationResult {
  duration: number;
  totalCost: number;
  simulationName: string;
  complexity: number;
  step: number;
  randomEventsDuration: number;
  authorName: string;
  procedureResults: IProcedureSimResult[];
  resourceResults: IResourceSimResult[];
  dateTime: Date;
  isSuccess: boolean;
  error: string;
}
