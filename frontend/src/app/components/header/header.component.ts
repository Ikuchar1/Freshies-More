import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true, // ✅ Required for standalone components
  imports: [CommonModule, RouterModule], // ✅ Ensure RouterModule is available for navigation
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {}
