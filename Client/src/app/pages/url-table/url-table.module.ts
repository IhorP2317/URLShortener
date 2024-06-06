import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UrlTableComponent } from './url-table.component';
import { RouterModule } from '@angular/router';
import {ReactiveFormsModule} from "@angular/forms";



@NgModule({
  declarations: [
    UrlTableComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        component: UrlTableComponent,
      },
    ]),
    ReactiveFormsModule,
  ],
  exports: [
    UrlTableComponent
  ]
})
export class UrlTableModule { }
