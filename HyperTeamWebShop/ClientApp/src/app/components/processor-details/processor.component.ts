import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Processor } from '../../models/processor';
import { ProcessorService } from '../../services/processor.service';
import { ProcessorsComponent } from '../processors/processors.component';

@Component({
  selector: 'app-processor',
  templateUrl: './processor.component.html'
})
export class ProcessorComponent implements OnInit {
  @Input() processor: Processor
  newProcessor: Processor
  socketTypes = ['AM3', 'AM4', 'FM2', 'LGA1050', 'LGA1051'];

  constructor(
    private processorService: ProcessorService,
    private processorComponent: ProcessorsComponent,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit(): void {
    if (!(this.location.path() =='/processors/new')) {
      this.getProcessor();
    }
  }

  getProcessor() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.processorService.getById(id).subscribe(motherboard => this.processor = motherboard);
  }

  goBack(): void {
    this.location.back();
  }

  deleteProcessor() {
    const id = +this.route.snapshot.paramMap.get('id');
    if (confirm("Are you sure to delete this item?")) {
      this.processorService.delete(id).subscribe(() => this.goBack());
    }
  }

  insertProcessor(socketType: string, cores: number, clockFrequency: number, l3CacheSize: number, smtSupport: boolean, manufacturer: string, type: string, price: number, imgUrl?: string): void {
    socketType = socketType.trim();
    cores = +cores.toString().trim();
    clockFrequency = +clockFrequency.toString().trim();
    l3CacheSize = +l3CacheSize.toString().trim();
    manufacturer = manufacturer.trim();
    imgUrl = imgUrl.trim();
    price = +price.toString().trim();

    if (!socketType && !cores && !clockFrequency && !l3CacheSize && !smtSupport && !manufacturer && !price) { return; }
    this.newProcessor = ({} as Processor);

    this.newProcessor.socketType = socketType;
    this.newProcessor.cores = cores;
    this.newProcessor.clockFrequency = clockFrequency;
    this.newProcessor.l3CacheSize = l3CacheSize;
    this.newProcessor.smtSupport = smtSupport == true ? true : false;
    this.newProcessor.manufacturer = manufacturer;
    this.newProcessor.type = type;
    this.newProcessor.imgURL = imgUrl !== "" ? imgUrl : "default.png";
    this.newProcessor.price = price;

    this.processorService.insert(this.newProcessor).subscribe(
      newProcessor => {
        this.processorComponent.processors.push(newProcessor);
        this.goBack();
      }
    )
  }

  updateProcessor(): void {
    this.processorService.update(this.processor).subscribe(() => this.goBack());
  }

}
