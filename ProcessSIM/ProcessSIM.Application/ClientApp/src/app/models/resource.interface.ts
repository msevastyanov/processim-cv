import {IResourceParameterValue} from "./resourceParameterValue.interface";

export interface IResource {
  id: number;
  name: string;
  price: number;
  type: string;
  category: string;
  parameters: IResourceParameterValue[];
}
