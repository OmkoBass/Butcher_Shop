import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ButcherService } from '../services/butcherService/butcherService/butcher-service.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  opened = false;
  loading = true;
  butcher = null;

  constructor(public butcherService: ButcherService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.butcherService.GetButcher()
    .subscribe(res => {
      this.butcher = res;
      this.loading = false;
    }, _ => {
      this.butcherService.handleLogOut();
      this.snackBar.open('Something went wrong!', 'Okay!');
    });
  }
}
