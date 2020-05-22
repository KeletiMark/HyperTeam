import { Processor } from "./processor";

export interface Motherboard {
  id: number;
  socketType: string;
  slotType: string;
  usb3Ports: number;
  wifiAdapter: boolean;
  motherBoardSize: string;
  compatibleProcessors: Processor[];
  manufacturer: string;
  type: string;
  imgURL: string;
  price: number;
}
