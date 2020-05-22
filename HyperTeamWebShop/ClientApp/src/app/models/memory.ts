import { Motherboard } from "./motherboard";

export interface Memory {
  id: number;
  slotType: string;
  clockFrequency: number;
  memorySizeInGb: number;
  height: number;
  latecy: number;
  compatibleMotherboards: Motherboard[];
  manufacturer: string;
  type: string;
  imgURL: string;
  price: number;
}
