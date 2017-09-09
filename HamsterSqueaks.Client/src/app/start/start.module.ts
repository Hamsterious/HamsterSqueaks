import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { StartComponent } from './start.component';

@NgModule({
  declarations: [
    StartComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [StartComponent]
})
export class StartModule { }
