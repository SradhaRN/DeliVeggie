import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductDetailsViewModel } from 'src/app/models/produst-detail';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product: ProductDetailsViewModel = new ProductDetailsViewModel();
  productId!: string;
  constructor(private route: ActivatedRoute,private productService: ProductService) { }
 
  ngOnInit(): void {
   this.productId = this.route.snapshot.paramMap.get('id') || '';
   this.productService.getProductDetailsById(this.productId as string).subscribe((product: ProductDetailsViewModel) => {
    return this.product = product;
  })
}

}