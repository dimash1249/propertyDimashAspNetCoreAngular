import { Property } from "../property/property";

export interface ResidentialComplex {
  id: string;
  residentialComplexName: string;
  addressStreet: string;
  addressNumber: string;
  properties: Property[];
}
