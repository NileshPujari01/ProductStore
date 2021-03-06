import { AfterViewInit, ChangeDetectorRef, Component, Input, OnInit, ViewChild } from '@angular/core';
import { ProductStoreService } from 'src/app/services/product-store.service';
import { MatTableDataSource } from "@angular/material/table";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort, Sort } from "@angular/material/sort";
import { MatDialog } from "@angular/material/dialog";
import { ProductItems } from 'src/app/models/products';
import { catchError, map, merge, of, startWith, switchMap } from 'rxjs';
import { DialogBoxComponent } from 'src/app/shared/components/dialog-box/dialog-box.component';
import { ProductApiRequest, ProductRequest } from 'src/app/models/product-request';

@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrls: ['./list-products.component.scss']
})
export class ListProductsComponent implements OnInit {
  @Input() userType!: string;
  public newRating!: String;
  public newRatingVal: number = 0;

  displayedColumns = ['productId', 'productName', 'productCategory', 'productPrice', 'productRating', "action"];
  public dataSource = new MatTableDataSource<any>();
  //public dataSource!: ProductItems[];
  public products!: ProductItems[];
  productRequest: ProductRequest = new ProductRequest()
  productApiRequest: ProductApiRequest = new ProductApiRequest()

  selectedValue = 'Rate';

  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    public service: ProductStoreService,
    public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.showData();
  }

  sortDataBasedOnValue(paramToSort: string) {
    const ascending: any= this.products.sort((a,b) =>  (a > b ? 1 : -1));
    const descending: any= this.products.sort((a,b) => (a > b ? -1 : 1))

    if (paramToSort == 'Rate') {
      this.products.sort((a, b) => a.productRating < b.productRating ? -1 : a.productRating > b.productRating ? 1 : 0)
    }
    if (paramToSort == 'Price') {
      this.products.sort((a, b) => a.productPrice < b.productPrice ? -1 : a.productPrice > b.productPrice ? 1 : 0)
    }
  }

  showData() {
    return this.service.getProducts().subscribe(data => {
      this.dataSource = data.products,
        this.products = data.products
    });
  }

  openDialog(action: any, obj: any) {
    obj.action = action;
    obj.userType = this.userType;
    const dialogRef = this.dialog.open(DialogBoxComponent, {
      width: '250px',
      data: obj
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result.event == 'Add') {
        this.addRowData(result.data);
      } else if (result.event == 'Update') {
        this.updateRowData(result.data);
      } else if (result.event == 'Delete') {
        this.deleteRowData(result.data);
      } else if (result.event == 'Rate') {
        this.rateProduct(result.data);
      }
    });
  }

  addRowData(row_obj: any) {
    this.productApiRequest.productName = row_obj.productName;
    this.productApiRequest.productCategory = row_obj.productCategory;
    this.productApiRequest.productPrice = row_obj.productPrice;
    this.productApiRequest.productRating = row_obj.productRating;
    this.productRequest.productRequest = this.productApiRequest;
    this.service.createProduct(this.productRequest).subscribe(x => {
      alert(`${row_obj.productName} saved successfully`);
      this.showData();
    }, (error) => {
      alert(`Issue while saving data`);
    });
  }

  updateRowData(row_obj: any) {
    this.productApiRequest.productId = row_obj.productId;
    this.productApiRequest.productName = row_obj.productName;
    this.productApiRequest.productCategory = row_obj.productCategory;
    this.productApiRequest.productPrice = row_obj.productPrice;
    this.productApiRequest.productRating = row_obj.productRating;
    this.productRequest.productRequest = this.productApiRequest;
    this.service.updateProduct(this.productRequest).subscribe(x => {
      alert(`${row_obj.productName} updated successfully`);
      this.showData();
    }, (error) => {
      alert(`Issue while saving data`);
    });
  }

  deleteRowData(row_obj: any) {
    this.service.deleteProduct(row_obj.productId).subscribe(x => {
      alert(`Record deleted successfully`);
      this.showData();
    }, (error) => {
      alert(`Issue while deletion`);
    });
  }

  public rateProduct(result: any) {
    this.service.rateProduct(result.productId, result.productRating).subscribe(x => {
      this.showData();
    });
  }
}
