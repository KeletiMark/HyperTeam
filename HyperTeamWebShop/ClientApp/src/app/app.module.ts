import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ProcessorsComponent } from './components/processors/processors.component';
import { ProcessorComponent } from './components/processor-details/processor.component';
import { MotherboardsComponent } from './components/motherboards/motherboards.component';
import { MotherboardComponent } from './components/motherboard-details/motherboard.component';
import { MemoriesComponent } from './components/memories/memories.component';
import { MemoryComponent } from './components/memory-details/memory.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProcessorsComponent,
    ProcessorComponent,
    MotherboardsComponent,
    MotherboardComponent,
    MemoriesComponent,
    MemoryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: '/index', pathMatch: 'full' },
      { path: 'index', component: HomeComponent },

      { path: 'motherboards', component: MotherboardsComponent },
      { path: 'motherboards/new', component: MotherboardComponent },
      { path: 'motherboards/:id', component: MotherboardComponent },
      { path: 'motherboards/:id/edit', component: MotherboardComponent },

      { path: 'memories', component: MemoriesComponent },
      { path: 'memories/new', component: MemoryComponent },
      { path: 'memories/:id', component: MemoryComponent },
      { path: 'memories/:id/edit', component: MemoryComponent },

      { path: 'processors', component: ProcessorsComponent },
      { path: 'processors/new', component: ProcessorComponent },
      { path: 'processors/:id', component: ProcessorComponent },
      { path: 'processors/:id/edit', component: ProcessorComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
