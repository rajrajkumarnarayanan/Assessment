import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  readonly ApiURL = 'https://localhost:44375/api'
  constructor(private http: HttpClient) { }
  
  
  public getProduct(){
    return this.http.get(this.ApiURL+'/Product/GetProduct');
  }

  public getProductById(id: string){
    const params = new HttpParams().set('id', id);
    return this.http.get(this.ApiURL+'/Product/GetProductDetails', { params: params });
  }
}
