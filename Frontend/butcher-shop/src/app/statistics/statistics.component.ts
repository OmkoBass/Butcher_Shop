import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { StatisticsService } from '../services/statisticsService/statistics.service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
  loading = true;
  stats = [];
  butcherStores = null;
  employees = null;
  storages = null;
  customers = null;
  articles = null;
  total = 0;

  single: any[];
  view: [number, number] = [1180, 400];

  showLegend = true;
  showLabels = true;

  colorScheme = {
    domain: ['#5AA454', '#E44D25', '#CFC0BB', '#7aa3e5', '#a8385d', '#aae3f5']
  };

  constructor(
    private statisticsService: StatisticsService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.statisticsService.GetCompleteButcherStores()
    .subscribe(res => {
      this.stats = res;
      this.butcherStores = res[0];
      this.employees = res[1];
      this.storages = res[2];
      this.customers = res[3];
      this.articles = res[4];
      // Yes i know i can use reduce
      // Couldn't be bothered for 5 things
      this.total = res[0].value + res[1].value + res[2].value + res[3].value + res[4].value;
      this.loading = false;
    }, () => {
      this.snackBar.open('Something went wrong!', 'Okay!');
      this.loading = false;
    });
  }
}
