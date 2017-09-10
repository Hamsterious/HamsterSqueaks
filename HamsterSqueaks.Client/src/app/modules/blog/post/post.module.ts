import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { IndexComponent } from './index/index.component';
import { PostRoutingModule } from './post-routing.module';

@NgModule({
  imports: [
    CommonModule,
    PostRoutingModule
  ],
  declarations: [IndexComponent],
  exports: [IndexComponent]
})
export class PostModule { }
