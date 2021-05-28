import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CreateButcherStoreDialogComponent } from '../create-butcher-store-dialog/create-butcher-store-dialog.component';
import { ButcherService } from '../services/butcherService/butcher-service.service';
import { ButcherStoreService } from '../services/butcherStoreService/butcher-store.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  loading = true;
  butcher = null;

  constructor(public butcherService: ButcherService, private butcherStoreService: ButcherStoreService, private snackBar: MatSnackBar, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.butcherService.GetButcher()
    .subscribe(res => {
      this.butcher = res;
      this.loading = false;
    }, _ => {
      this.snackBar.open('Something went wrong!', 'Okay!');
    });
  }
  
  handleOpenAddButcherStoreDialog() {
    this.dialog.open(CreateButcherStoreDialogComponent, {
      width: '60%',
      minWidth: '320px'
    })
    .afterClosed()
    .subscribe(res => {
      if(res) {
        this.butcher.butcherStores.push(res.data);
      }
    });
  }

  handleDeleteStore(id) {
    this.butcherStoreService.DeleteButcherStore(id)
    .subscribe(_ => {
      this.butcher.butcherStores = this.butcher.butcherStores.filter(store => store.id !== id); 
      this.snackBar.open('Butcher Store deleted!', 'Okay!');
    }, () => {
      this.snackBar.open('Something went wrong!', 'Okay!');
    });
  }
}
