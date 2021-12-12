import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor(private $route: ActivatedRoute,public productService:ProductService) { }
  id:any;
  product:any;
  ngOnInit(): void {
    this.$route.params.forEach(param =>
      this.id = param['id']
    );
    this.productService.getProductById(this.id).subscribe((data: any) => {
      if (data) {
        this.product = data.product;
      } 
    });
  }

}
