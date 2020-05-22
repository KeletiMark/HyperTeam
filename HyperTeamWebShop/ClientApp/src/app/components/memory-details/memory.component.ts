import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Memory } from '../../models/memory';
import { MemoryService } from '../../services/memory.service';
import { MemoriesComponent } from '../memories/memories.component'

@Component({
  selector: 'app-memory',
  templateUrl: './memory.component.html'
})
export class MemoryComponent implements OnInit {
  @Input() memory: Memory
  newMemory: Memory

  constructor(
    private memoryService: MemoryService,
    private memoriesComponent: MemoriesComponent,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit(): void {
    if (!(this.location.path()=='/memories/new')) {
      this.getMemory();
    }
  }

  getMemory() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.memoryService.getById(id).subscribe(memory => this.memory = memory);
  }

  goBack(): void {
    this.location.back();
  }

  deleteMemory() {
    const id = +this.route.snapshot.paramMap.get('id');
    if (confirm("Are you sure to delete this item?")) {
      this.memoryService.delete(id).subscribe(() => this.goBack());
    }
  }

  insertMemory(slotType: string, clockFrequency: number, memorySize: number, height: number, latecy: number, manufacturer: string, type: string, price: number, imgUrl?: string): void {
    slotType = slotType.trim();
    clockFrequency = +clockFrequency.toString().trim();
    memorySize = +memorySize.toString().trim();
    height = +height.toString().trim();
    latecy = +latecy.toString().trim();
    manufacturer = manufacturer.trim();
    imgUrl = imgUrl.trim();
    price = +price.toString().trim();

    if (!slotType && !clockFrequency && !memorySize && !height && !latecy && !manufacturer && !price) { return; }
    this.newMemory = ({} as Memory);

    this.newMemory.slotType = slotType;
    this.newMemory.clockFrequency = clockFrequency;
    this.newMemory.memorySizeInGb = memorySize;
    this.newMemory.height = height;
    this.newMemory.latecy = latecy;
    this.newMemory.manufacturer = manufacturer;
    this.newMemory.type = type;
    this.newMemory.imgURL = imgUrl !== "" ? imgUrl : "default.png";
    this.newMemory.price = price;

    this.memoryService.insert(this.newMemory).subscribe(
      newMemory => {
        this.memoriesComponent.memories.push(newMemory);
        this.goBack();
      }
    )
  }

  updateMemory(): void {
    this.memoryService.update(this.memory).subscribe(() => this.goBack());
  }

}
