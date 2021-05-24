import { Component, OnInit } from '@angular/core';
import { ButcherStoreService } from '../services/butcherStoreService/butcher-store.service';
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { EditEmployeeDialogComponent } from '../edit-employee-dialog/edit-employee-dialog.component';
import { Location } from "@angular/common";

@Component({
  selector: 'app-butcher-store',
  templateUrl: './butcher-store.component.html',
  styleUrls: ['./butcher-store.component.css']
})
export class ButcherStoreComponent implements OnInit {
  loading = true;
  butcherStore = null;

  constructor(private butcherStoreService: ButcherStoreService, private router: Router, private snackBar: MatSnackBar, public dialog: MatDialog, private location: Location) { }

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

  handleOpenEditDialog(employee) {
    this.dialog.open(EditEmployeeDialogComponent, {
      data: {
        name: employee.name,
        lastname: employee.lastname,
        address: employee.address,
        job: employee.job,
        sex: employee.sex
      },
      width: '60%',
      minWidth: '320px'
    });
  }
}
