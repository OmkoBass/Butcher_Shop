import { Component, OnInit } from '@angular/core';
import { ButcherStoreService } from '../services/butcherStoreService/butcher-store.service';
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { EditEmployeeDialogComponent } from '../edit-employee-dialog/edit-employee-dialog.component';
import { Location } from "@angular/common";
import { EmployeeService } from '../services/employeeService/employee-service.service';
import { EditStorageDialogComponent } from '../edit-storage-dialog/edit-storage-dialog.component';
import { StorageService } from '../services/storageService/storage.service';
import { CustomerService } from '../services/customerService/customer.service';
import { EditCustomerDialogComponent } from '../edit-customer-dialog/edit-customer-dialog.component';

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
  searchStorageValue = null;
  searchCustomersValue = null;

  constructor(
    private butcherStoreService: ButcherStoreService,
    private storageService: StorageService,
    private employeeService: EmployeeService, 
    private customerService: CustomerService,
    private router: Router, 
    private snackBar: MatSnackBar, 
    public dialog: MatDialog, 
    private location: Location
    ) { }

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

  handleSearchStorage(value) {
    this.searchStorageValue = value;
  }

  handleSearchCustomers(value) {
    this.searchCustomersValue = value;
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

  handleDeleteStorage(id: string) {
    this.submitting = true;
    this.storageService.DeleteStorage(id)
    .subscribe(_ => {
      this.butcherStore.storages = this.butcherStore.storages.filter(storage => storage.id !== id);
      this.snackBar.open('Storage deleted!', 'Okay!');
      this.submitting = false;
    }, () => {
      this.snackBar.open('Something went wrong!', 'Okay!');
      this.submitting = false;
    });
  }

  handleShowAddStorageDialog() {
    this.dialog.open(EditStorageDialogComponent, {
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
        this.butcherStore.storages = [...this.butcherStore.storages, res.data];
      }
    });
  }

  handleOpenEditStorageDialog(storage) {
    this.dialog.open(EditStorageDialogComponent, {
      data: {
        id: storage.id,
        address: storage.address,
        area: storage.area,
        butcherStoreId: this.butcherStore.id
      },
      width: '60%',
      minWidth: '320px'
    })
    .afterClosed()
    .subscribe(res => {
      if(res) {
        this.butcherStore.storages = this.butcherStore.storages.map(storage => {
          if(storage.id === res.data.id) {
            return res.data;
          }
  
          return storage;
        });
      }
    });
  }

  handleOpenEditCustomerDialog(customer) {
    this.dialog.open(EditCustomerDialogComponent, {
      data: {
        id: customer.id,
        name: customer.name,
        lastname: customer.lastname,
        address: customer.address,
        sex: customer.sex,
        butcherStoreId: this.butcherStore.id
      },
      width: '60%',
      minWidth: '320px'
    })
    .afterClosed()
    .subscribe(res => {
      if(res) {
        this.butcherStore.customers = this.butcherStore.customers.map(customer => {
          if(customer.id === res.data.id) {
            return res.data;
          }
  
          return customer;
        });
      }
    });
  }

  handleDeleteCustomer(id: string) {
    this.submitting = true;
    this.customerService.DeleteCustomer(id)
    .subscribe(_ => {
      this.butcherStore.customers = this.butcherStore.customers.filter(customer => customer.id !== id);
      this.snackBar.open('Customer Deleted!', 'Okay!');
      this.submitting = false;
    }, () => {
      this.snackBar.open('Something went wrong!', 'Okay!');
      this.submitting = false;
    });
  }
}
