import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ButcherStoreComponent } from './butcher-store/butcher-store.component';
import { CustomerArticlesComponent } from './customer-articles/customer-articles.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { StorageArticlesComponent } from './storage-articles/storage-articles.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        component: HomeComponent
      },
      {
        path: 'statistics',
        component: StatisticsComponent
      },
      {
        path: 'butcherStore/:butcherStoreId',
        component: ButcherStoreComponent
      },
      {
        path: 'storage/:storageId',
        component: StorageArticlesComponent
      },
      {
        path: 'customer/:customerId',
        component: CustomerArticlesComponent
      }
    ]
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
