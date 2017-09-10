import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { Routes } from '@angular/router';

import { FrontPageComponent } from './components/front-page/front-page.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

const routes: Routes = [
    { path: '', component: FrontPageComponent },
    { path: '**', component: PageNotFoundComponent },
    { path: 'posts', loadChildren: '../modules/blog/post/post.module#PostModule' }
];

@NgModule({
    imports: [
        CommonModule
    ],
    exports: [],
    declarations: [
        PageNotFoundComponent,
        FrontPageComponent
    ]
})
export class RoutingModule { }
export const Routing = routes;
