import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { FreshiesComponent } from './pages/freshies/freshies.component';
import { TshirtsComponent } from './pages/tshirts/tshirts.component';
import { ProductDetailComponent } from './pages/product-detail.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'freshies', component: FreshiesComponent },
  { path: 'tshirts', component: TshirtsComponent },
  { path: 'products/:id', component: ProductDetailComponent}
];
