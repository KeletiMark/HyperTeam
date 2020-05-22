import { Motherboard } from "./motherboard";

export interface Processor {
  id: number;
  socketType: string;
  cores: number;
  clockFrequency: number;
  l3CacheSize: number;
  smtSupport: boolean;
  compatibleMotherboards: Motherboard[];
  manufacturer: string;
  type: string;
  imgURL: string;
  price: number;
}
