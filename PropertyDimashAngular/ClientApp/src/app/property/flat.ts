import { ResidentialComplex } from "../residentialComplex/residential-complex";
import { Property } from "./property";

export interface Flat {
  propertyFloor: number;
  totalFloor: number;
  formerDormitory: boolean;
  balcony: string;
  balconyGlazed: boolean;
  door: string;
  parking: string;
  propertyFurnished: string;
  floor: string;
  residentialComplexName: string;
  residentialComplex: ResidentialComplex
}
