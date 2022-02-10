import { Component, Inject, OnInit, Optional } from '@angular/core';
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

  constructor(
    public _productService: ProductStoreService,
    public dialogRef: MatDialogRef<DialogBoxComponent>,
    //@Optional() is used to prevent error if no data is passed
    @Optional() @Inject(MAT_DIALOG_DATA) public data: ProductItems) {
    this.local_data = {...data};
    this.action = this.local_data.action;
    this.userType = this.local_data.userType;
  }

  ngOnInit(): void {
    this._productService.getCategory().subscribe(x => {this.categoryList = x.productCategories});
  }

  doAction(){
    this.dialogRef.close({event:this.action,data:this.local_data});
  }

  closeDialog(){
    this.dialogRef.close({event:'Cancel'});
  }

}
