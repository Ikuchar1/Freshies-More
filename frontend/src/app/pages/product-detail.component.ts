import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CommonModule, NgFor, NgIf} from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-product-detail',
  standalone: true,
  imports: [CommonModule, NgFor, NgIf, FormsModule],
  templateUrl: './product-detail.component.html',
  styleUrl: './product-detail.component.scss'
})
export class ProductDetailComponent implements OnInit {
  product: any;

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient
  ) {}

  ngOnInit(): void {
    //gets the id from the url
    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      this.http.get<any>(`http://localhost:5246/api/products/${id}`)
        .subscribe(data => {
          this.product = data;
        });
    }
  }

  selectedSize: string | null = null;
}
