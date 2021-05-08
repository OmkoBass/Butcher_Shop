import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ButcherService } from '../services/butcherService/butcherService/butcher-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  loading = true;
  butcher = null;

  constructor(public butcherService: ButcherService, private router: Router) { }

  ngOnInit(): void {
    this.butcherService.GetButcher()
    .subscribe(res => {
      this.butcher = res;
      this.loading = false;
      console.log(res);
    }, _ => {
      this.butcherService.handleLogOut();
    });
  }
}
