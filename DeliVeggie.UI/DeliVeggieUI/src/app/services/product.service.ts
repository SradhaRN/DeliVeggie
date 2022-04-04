import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { ProductViewModel } from '../models/product';
import { Observable } from 'rxjs';
import { ProductDetailsViewModel } from '../models/product-detail';

@Injectable({
  providedIn: 'root'
})

export class ProductService {

  baseUrl = 'https://localhost:44348/api/';

  constructor(private http: HttpClient) { }

  getAllProducts() : Observable<ProductViewModel[]>
  {
    return this.http.get<any>(this.baseUrl + 'product/');
  }
  getProductDetailsById(id: string): Observable<ProductDetailsViewModel>
  {
    return this.http.get<any>(this.baseUrl + 'product/' + id);
  }
}