import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { PostModule } from '../modules/blog/post/post.module';
import { Routing, RoutingModule } from '../routing/routing.module';
import { StartComponent } from './start.component';
import { NavigationModule } from '../navigation/navigation.module';

@NgModule({
  declarations: [
    StartComponent
  ],
  imports: [
    BrowserModule,
    RoutingModule,
    PostModule,
    RouterModule.forRoot(Routing),
    NavigationModule
  ],
  providers: [],
  bootstrap: [StartComponent]
})
export class StartModule { }
