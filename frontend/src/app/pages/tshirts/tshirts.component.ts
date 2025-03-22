import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule, NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-tshirts',
  standalone: true,
  imports: [CommonModule, NgFor],
  templateUrl: './tshirts.component.html',
  styleUrl: './tshirts.component.scss'
})
export class TshirtsComponent implements OnInit {
  tshirts: any[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<any[]>('http://localhost:5246/api/products?hasSizes=true')
      .subscribe(data => {
        this.tshirts = data;
      })
  }
}
