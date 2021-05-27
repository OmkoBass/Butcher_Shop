import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ButcherStoreService } from '../services/butcherStoreService/butcher-store.service';

@Component({
  selector: 'app-create-butcher-store-dialog',
  templateUrl: './create-butcher-store-dialog.component.html',
  styleUrls: ['./create-butcher-store-dialog.component.css']
})
export class CreateButcherStoreDialogComponent implements OnInit {
  addButcherStoreForm: FormGroup;
  submitting = false;

  constructor(private formBuilder: FormBuilder, public dialogRef : MatDialogRef<CreateButcherStoreDialogComponent>, private butcherStoreService: ButcherStoreService, private snackBar: MatSnackBar) {
    this.addButcherStoreForm = this.formBuilder.group({
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(32)
        ]
      ],
      address: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(64)
        ]
      ],
      area: [
        0,
        [
          Validators.required,
          Validators.min(1)
        ]
      ]
    });
  }

  get name() {
    return this.addButcherStoreForm.get('name');
  }

  get address() {
    return this.addButcherStoreForm.get('address');
  }

  get area() {
    return this.addButcherStoreForm.get('area');
  }

  ngOnInit(): void {
    this.addButcherStoreForm.reset();
  }

  handleSubmit(form) {
    this.submitting = true;
    this.butcherStoreService.CreateButcherStore(form.value)
    .subscribe(res => {
      this.snackBar.open('Butcher store added!', 'Okay!');
      this.submitting = false;
      this.dialogRef.close({ data: res });
    }, () => {
      this.submitting = false;
      this.snackBar.open('Something went wrong!', 'Okay!');
    });
  }

  handleCloseDialog() {
    this.dialogRef.close();
  }
}
