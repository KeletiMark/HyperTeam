import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { MotherboardService } from '../../services/motherboard.service';
import { MotherboardsComponent } from '../motherboards/motherboards.component';
import { Motherboard } from '../../models/motherboard';

@Component({
  selector: 'app-motherboard',
  templateUrl: './motherboard.component.html'
})
export class MotherboardComponent implements OnInit {
  @Input() motherboard: Motherboard
  newMotherboard: Motherboard

  constructor(
    private motherboardService: MotherboardService,
    private motherboardsComponent: MotherboardsComponent,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit(): void {
    if (!(this.location.path() =='/motherboards/new')) {
      this.getMotherboard();
    }
  }

  getMotherboard() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.motherboardService.getById(id).subscribe(motherboard => this.motherboard = motherboard);
  }

  goBack(): void {
    this.location.back();
  }

  deleteMotherboard() {
    const id = +this.route.snapshot.paramMap.get('id');
    if (confirm("Are you sure to delete this item?")) {
      this.motherboardService.delete(id).subscribe(() => this.goBack());
    }
  }

  insertMotherboard(socketType: string, slotType: string, usB3Ports: number, wifiAdapter: boolean, motherBoardSize: string, manufacturer: string, type: string, price: number, imgUrl?: string): void {
    socketType = socketType.trim();
    slotType = slotType.trim();
    usB3Ports = +usB3Ports.toString().trim();
    motherBoardSize = motherBoardSize.trim();
    manufacturer = manufacturer.trim();
    imgUrl = imgUrl.trim();
    price = +price.toString().trim();

    if (!socketType && !slotType && !usB3Ports && !wifiAdapter && !motherBoardSize && !manufacturer && !price) { return; }
    this.newMotherboard = ({} as Motherboard);

    this.newMotherboard.socketType = socketType;
    this.newMotherboard.slotType = slotType;
    this.newMotherboard.usb3Ports = usB3Ports;
    this.newMotherboard.wifiAdapter = wifiAdapter == true ? true : false;
    this.newMotherboard.motherBoardSize = motherBoardSize;
    this.newMotherboard.manufacturer = manufacturer;
    this.newMotherboard.type = type;
    this.newMotherboard.imgURL = imgUrl !== "" ? imgUrl : "default.png";
    this.newMotherboard.price = price;

    this.motherboardService.insert(this.newMotherboard).subscribe(
      newMotherboard => {
        this.motherboardsComponent.motherboards.push(newMotherboard);
        this.goBack();
      }
    )
  }

  updateMotherboard(): void {
    this.motherboardService.update(this.motherboard).subscribe(() => this.goBack());
  }

}
