import { Processor } from "./processor";
import { Memory } from "./memory";

export interface Motherboard {
  id: number;
  socketType: string;
  slotType: string;
  usb3Ports: number;
  wifiAdapter: boolean;
  motherBoardSize: string;
  compatibleProcessors: Processor[];
  compatibleMemories: Memory[];
  manufacturer: string;
  type: string;
  imgURL: string;
  price: number;
}
