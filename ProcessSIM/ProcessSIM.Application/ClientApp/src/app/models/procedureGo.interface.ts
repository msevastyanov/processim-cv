import {IProcedureParameter} from "./procedureParameter.interface";

export interface IProcedureGo {
  key: string;
  name: string;
  alias: string;
  resourcesList: string;
  progressFunction: string;
  parameters: IProcedureParameter[];
}
