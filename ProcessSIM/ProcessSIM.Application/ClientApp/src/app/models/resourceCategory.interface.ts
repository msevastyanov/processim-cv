import {IResourceType} from "./resourceType.interface";

export interface IResourceCategory {
  id: number;
  name: string;
  resourceTypes: IResourceType[];
}
