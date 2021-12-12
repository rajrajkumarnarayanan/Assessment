import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  
  constructor(private productService:ProductService) { }
  productList:any;
  ngOnInit(): void {
    this.productService.getProduct().subscribe((data: any) => {
      if (data) {
        this.productList = data.productList;
      } 
    });
  }

}
