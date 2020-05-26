import { Component, OnInit, Injectable } from '@angular/core';

import { Processor } from '../../models/processor';
import { ProcessorService } from '../../services/processor.service';

@Injectable({
  providedIn: 'root'
})
@Component({
  selector: 'app-processors',
  templateUrl: './processors.component.html'
})
export class ProcessorsComponent implements OnInit{
  public processors: Processor[] = [];
  private view: string = "list";

  constructor(private processorService: ProcessorService) { }

  ngOnInit(): void
  {
    this.getProcessors();
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

  getProcessors(): void {
    this.processorService.getAll().subscribe(processors => this.processors = processors);
  }

}

