import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { productCategory } from 'src/app/models/product-category';
import { ProductStoreService } from 'src/app/services/product-store.service';
import { ProductItems } from '../../../models/products';

@Component({
  selector: 'app-dialog-box',
  templateUrl: './dialog-box.component.html',
  styleUrls: ['./dialog-box.component.scss']
})
export class DialogBoxComponent implements OnInit {
  public userType!: string;
  action:string;
  local_data:any;
  public categoryList!: any[];
  public selectedValue!: number;

  constructor(
    public _productService: ProductStoreService,
    public dialogRef: MatDialogRef<DialogBoxComponent>,
    //@Optional() is used to prevent error if no data is passed
    @Optional() @Inject(MAT_DIALOG_DATA) public data: ProductItems) {
    this.local_data = {...data};
    this.action = this.local_data.action;
    this.userType = this.local_data.userType;
    this._productService.getCategory().subscribe(x => {this.categoryList = x.productCategories});
  }

  ngOnInit(): void {
    this.selectedValue = this.local_data.productCategory;
  }

  doAction(){
    console.log(this.local_data);
    this.dialogRef.close({event:this.action,data:this.local_data});
  }

  closeDialog(){
    this.dialogRef.close({event:'Cancel'});
  }

  compareFn(v1: productCategory, v2: productCategory): boolean {
    return compareObjects(v1, v2);
}
}

function compareObjects(o1: any, o2: any): boolean {
  return o1.name === o2.name && o1.id === o2.id;
}

