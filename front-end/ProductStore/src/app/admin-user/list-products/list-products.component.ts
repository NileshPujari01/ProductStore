import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { ProductStoreService } from 'src/app/services/product-store.service';
import { MatTable, MatTableDataSource } from "@angular/material/table";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatDialog } from "@angular/material/dialog";
import { ProductItems, Products } from 'src/app/models/products';
import { catchError, map, merge, of, startWith, switchMap } from 'rxjs';
import { DialogBoxComponent } from 'src/app/dialog-box/dialog-box.component';
import { ProductApiRequest, ProductRequest } from 'src/app/models/product-request';

@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrls: ['./list-products.component.scss']
})
export class ListProductsComponent implements OnInit {

  displayedColumns = ['productId', 'productName', 'productCategory', 'productPrice', 'productRating', "action"];
  public dataSource!: ProductItems[];
  
  productRequest: ProductRequest = new ProductRequest()
  productApiRequest: ProductApiRequest = new ProductApiRequest()
  
  @ViewChild(MatTable,{static:true}) table!: MatTable<any>;
  @ViewChild(MatPaginator, {static: true}) paginator!: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;

  constructor(private service: ProductStoreService, public dialog: MatDialog) { }

  ngOnInit(): void{
    this.showData();
  }

  showData() {
// this.dataSource.paginator = this.paginator;
    // this.dataSource.sort = this.sort;

    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    merge(this.sort.sortChange, this.paginator.page)
      .pipe(
        startWith({}),
        switchMap(() => {
          return this.service.getProducts(this.sort.active, this.sort.direction, this.paginator.pageIndex);}),
        map(data => {
          return data;
        }),
        catchError(() => {
          return of([]);
        })
      ).subscribe(data => {this.dataSource = data.products});      
  }

  openDialog(action: any,obj: any) {
    obj.action = action;
    const dialogRef = this.dialog.open(DialogBoxComponent, {
      width: '250px',
      data:obj
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result.event == 'Add'){
        this.addRowData(result.data);
      }else if(result.event == 'Update'){
        this.updateRowData(result.data);
      }else if(result.event == 'Delete'){
        this.deleteRowData(result.data);
      }
    });
  }

  addRowData(row_obj: any){
    this.dataSource.push({
      productId: row_obj.productId,
      productName:row_obj.productName,
      productCategory:row_obj.productCategory,
      productPrice:row_obj.productPrice,
      productRating:row_obj.productRating
    });
    this.productApiRequest.productName = row_obj.productName;
    this.productApiRequest.productCategory = row_obj.productCategory;
    this.productApiRequest.productPrice = row_obj.productPrice;
    this.productApiRequest.productRating = row_obj.productRating;
    this.productRequest.productRequest = this.productApiRequest;
    this.service.createProduct(this.productRequest).subscribe(x => {
      alert(`${row_obj.productName} saved successfully`);
    }, (error) => {
      alert(`Issue while saving data`);
    });
   
    this.showData();
    
  }
  updateRowData(row_obj: any){
    this.dataSource = this.dataSource.filter((value,key)=>{
      if(value.productId == row_obj.productId){
        value.productName = row_obj.productName;
        value.productCategory = row_obj.productCategory;
        value.productPrice = row_obj.productPrice;
        value.productRating = row_obj.productRating;
      }
      return true;
    });
    this.productApiRequest.productId = row_obj.productId;
    this.productApiRequest.productName = row_obj.productName;
    this.productApiRequest.productCategory = row_obj.productCategory;
    this.productApiRequest.productPrice = row_obj.productPrice;
    this.productApiRequest.productRating = row_obj.productRating;
    this.productRequest.productRequest = this.productApiRequest;
    this.service.updateProduct(this.productRequest).subscribe(x => {
      alert(`${row_obj.productName} saved successfully`);
    }, (error) => {
      alert(`Issue while saving data`);
    });

    this.showData();
  }

  deleteRowData(row_obj: any){
    this.dataSource = this.dataSource.filter((value,key)=>{
      return value.productId != row_obj.productId;
    });
    this.service.deleteProduct(row_obj.productId).subscribe(x => {
      alert(`${row_obj.productName} deleted successfully`);
    }, (error) => {
      alert(`Issue while deletion`);
    });

    this.showData();
  }
}
