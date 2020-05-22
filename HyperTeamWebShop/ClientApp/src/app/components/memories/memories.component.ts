import { Component, OnInit, Injectable } from '@angular/core';

import { Memory } from '../../models/memory';
import { MemoryService } from '../../services/memory.service';

@Injectable({
  providedIn: 'root'
})
@Component({
  selector: 'app-memories',
  templateUrl: './memories.component.html'
})
export class MemoriesComponent implements OnInit{
  public memories: Memory[] = [];
  private view: string = "card";

  constructor(private memoryService: MemoryService) { }

  ngOnInit(): void
  {
    this.getMemories();
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

  getMemories(): void {
    this.memoryService.getAll().subscribe(memories => this.memories = memories);
  }

}

