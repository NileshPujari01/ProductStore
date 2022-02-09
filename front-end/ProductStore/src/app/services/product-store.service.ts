import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ProductRequest } from '../models/product-request';
import { ProductItems, Products } from '../models/products';

@Injectable()
export class ProductStoreService {

  constructor(private _httpClient: HttpClient) { }

  getProducts(): Observable<any> {
    return this._httpClient.get<any>(`${environment.productStoreApiHost}ProductStore/GetProducts`);
  }

  createProduct(productModel: ProductRequest): Observable<any> {
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(productModel);
    return this._httpClient.post(`${environment.productStoreApiHost}ProductStore/CreateProduct`,  body,{'headers':headers});
  }

  updateProduct(productModel: ProductRequest): Observable<any> {
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(productModel);
    return this._httpClient.post(`${environment.productStoreApiHost}ProductStore/UpdateProduct`, body,{'headers':headers});
  }

  deleteProduct(productId: number): Observable<any> {
    // const headers = { 'content-type': 'application/json'}  
    // const body=JSON.stringify({"deleteProduct" : productId});
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        deleteProduct: productId
      },
    };
    return this._httpClient.delete(`${environment.productStoreApiHost}ProductStore/DeleteProduct`,options );
  }

  rateProduct(productId: number, productRating: number){
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify({ratingRequest : {
      productId: productId,
      productRating: productRating
      }});
    return this._httpClient.post(`${environment.productStoreApiHost}ProductStore/SetProductRating`, body,{'headers':headers});
  }
}

