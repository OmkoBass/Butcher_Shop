import { Component, OnInit } from '@angular/core';
import { ButcherStoreService } from '../services/butcherStoreService/butcher-store.service';
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { EditEmployeeDialogComponent } from '../edit-employee-dialog/edit-employee-dialog.component';
import { Location } from "@angular/common";
import { EmployeeService } from '../services/employeeService/employee-service.service';

@Component({
  selector: 'app-butcher-store',
  templateUrl: './butcher-store.component.html',
  styleUrls: ['./butcher-store.component.css']
})
export class ButcherStoreComponent implements OnInit {
  loading = true;
  butcherStore = null;
  searchValue = null;
  submitting = false;

  constructor(private butcherStoreService: ButcherStoreService, private employeeService: EmployeeService, private router: Router, private snackBar: MatSnackBar, public dialog: MatDialog, private location: Location) { }

  ngOnInit(): void {
    // I'm gonna do it like this
    // Because angular's router is retarded
    const urlParam = this.router.url.split("/")[2];

    this.butcherStoreService.GetButcherStore(urlParam)
    .subscribe(res => {
      this.butcherStore = res;
      this.loading = false;
    }, _ => {
      this.loading = false;
      this.snackBar.open('Something went wrong!', 'Okay!');
    });
  }

  handleGoBack() {
    this.location.back();
  }

  handleSearch(value) {
    this.searchValue = value
  }

  handleOpenEditDialog(employee) {
    this.dialog.open(EditEmployeeDialogComponent, {
      data: {
        id: employee.id,
        name: employee.name,
        lastname: employee.lastname,
        address: employee.address,
        job: employee.job,
        sex: employee.sex,
        butcherStoreId: this.butcherStore.id
      },
      width: '60%',
      minWidth: '320px'
    })
    .afterClosed()
    .subscribe(res => {
      if(res) {
        this.butcherStore.employees = this.butcherStore.employees.map(employee => {
          if(employee.id === res.data.id) {
            return res.data;
          }
  
          return employee;
        });
      }
    });
  }

  handleShowAddEmployeeDialog() {
    this.dialog.open(EditEmployeeDialogComponent, {
      data: {
        new: true,
        butcherStoreId: this.butcherStore.id
      },
      width: '60%',
      minWidth: '320px'
    })
    .afterClosed()
    .subscribe(res => {
      if(res) {
        this.butcherStore.employees = [...this.butcherStore.employees, res.data];
      }
    });
  }

  handleDeleteEmployee(id: string) {
    this.submitting = true;
    this.employeeService.DeleteEmployee(id)
    .subscribe(_ => {
      this.butcherStore.employees = this.butcherStore.employees.filter(employee => employee.id !== id);
      this.snackBar.open('Employee deleted!', 'Okay!');
      this.submitting = false;
    }, () => {
      this.snackBar.open('Something went wrong!', 'Okay!');
      this.submitting = false;
    });
  }
}
