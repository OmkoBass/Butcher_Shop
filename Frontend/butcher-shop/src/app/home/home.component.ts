import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ButcherService } from '../services/butcherService/butcher-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  loading = true;
  butcher = null;

  constructor(public butcherService: ButcherService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.butcherService.GetButcher()
    .subscribe(res => {
      this.butcher = res;
      this.loading = false;
    }, _ => {
      this.snackBar.open('Something went wrong!', 'Okay!');
    });
  }
}
