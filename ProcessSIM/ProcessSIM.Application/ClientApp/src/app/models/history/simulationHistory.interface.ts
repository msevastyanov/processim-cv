import {IResourceHistory} from "./resourceHistory.interface";
import {IProcedureHistory} from "./procedureHistory.interface";

export interface ISimulationHistory {
  simulationHistoryId: number;
  duration: number;
  waitingTime: number;
  totalCost: number;
  complexity: number;
  resources: IResourceHistory[];
  procedures: IProcedureHistory[];
}
