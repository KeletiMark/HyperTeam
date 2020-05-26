import { Component, OnInit, Injectable } from '@angular/core';

import { Motherboard } from '../../models/motherboard';
import { MotherboardService } from '../../services/motherboard.service';

@Injectable({
  providedIn: 'root'
})
@Component({
  selector: 'app-motherboards',
  templateUrl: './motherboards.component.html'
})
export class MotherboardsComponent implements OnInit {
  public motherboards: Motherboard[] = [];
  private view: string = "list";

  constructor(private motherboardService: MotherboardService) { }

  ngOnInit(): void
  {
    this.getMotherboards();
  }

  setViewCard(): void {
    this.view = "card";
  }

  setViewList(): void {
    this.view = "list";
  }

  setViewTable(): void {
    this.view = "table";
  }

  getMotherboards(): void {
    this.motherboardService.getAll().subscribe(motherboards => this.motherboards = motherboards);
  }

}

