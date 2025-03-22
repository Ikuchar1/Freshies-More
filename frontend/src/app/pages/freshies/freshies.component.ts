import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule, NgFor, NgIf } from '@angular/common';


@Component({
  selector: 'app-freshies',
  standalone: true,
  imports: [CommonModule, NgFor],
  templateUrl: './freshies.component.html',
  styleUrl: './freshies.component.scss'
})
export class FreshiesComponent implements OnInit {

  freshies: any[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<any[]>('http://localhost:5246/api/products?hasSizes=false')
      .subscribe(data => {
        this.freshies = data;
      })
  }

}
