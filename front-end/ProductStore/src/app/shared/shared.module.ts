import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ListProductsComponent } from './components/list-products/list-products.component';
import { MatTableModule } from "@angular/material/table";
import { HttpClientModule } from '@angular/common/http';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { DialogBoxComponent } from './components/dialog-box/dialog-box.component';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [
    ListProductsComponent,
    DialogBoxComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    HttpClientModule,
    MatSortModule,
    MatDialogModule,
    MatFormFieldModule,
    MatCardModule,
    FormsModule,
    MatInputModule,
    MatListModule,
    MatSelectModule
  ],
  exports: [
    ListProductsComponent,
    DialogBoxComponent
  ]
})
export class SharedModule { }
