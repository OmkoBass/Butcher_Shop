import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EmployeeService } from '../services/employeeService/employee-service.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  loading = true;
  employees = [];

  constructor(private employeeService: EmployeeService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.employeeService.GetEmployeesForButcherStore()
    .subscribe(res => {
      this.employees = res;
      this.loading = true;
    }, (_) => {
      this.snackBar.open('Something went wrong!', 'Okay!')
      this.loading = false;
    });
  }
}
