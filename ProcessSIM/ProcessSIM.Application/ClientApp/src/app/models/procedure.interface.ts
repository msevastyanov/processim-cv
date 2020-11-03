import {IProcedureParameter} from "./procedureParameter.interface";

export interface IProcedure {
  name: string;
  alias: string;
  resourcesList: string;
  progressFunction: string;
  parameters: IProcedureParameter[];
}
