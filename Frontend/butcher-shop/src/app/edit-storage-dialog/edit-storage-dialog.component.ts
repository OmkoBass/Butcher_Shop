import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { StorageService } from '../services/storageService/storage.service';

@Component({
  selector: 'app-edit-storage-dialog',
  templateUrl: './edit-storage-dialog.component.html',
  styleUrls: ['./edit-storage-dialog.component.css']
})
export class EditStorageDialogComponent implements OnInit {
  storageForm: FormGroup
  submitting = false;

  constructor(
    private formBuilder: FormBuilder, 
    @Inject(MAT_DIALOG_DATA) public storage,
    public dialogRef : MatDialogRef<EditStorageDialogComponent>,
    private storageService: StorageService,
    private snackBar: MatSnackBar
    ) { }

  ngOnInit(): void {
    this.storageForm = this.formBuilder.group({
      address: [
        this.storage.address,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(64),
        ]
      ],
      area: [
        this.storage.area,
        [
          Validators.required,
          Validators.min(1)
        ]
      ]
    });
  }

  handleSubmit(form) {
    this.submitting = true;
    
    const storage = {...form.value, butcherStoreId: this.storage.butcherStoreId }

    if(this.storage.new) {
      this.storageService.CreateStorage(storage)
      .subscribe(res => {
        this.dialogRef.close({ data: res });
        this.submitting = false;
        this.snackBar.open('Storage Added!', 'Okay!');
      }, () => {
        this.submitting = false;
        this.snackBar.open('Something went wrong!', 'Okay!');
      });
    } else {
      this.storageService.UpdateStorage(this.storage.id, storage)
      .subscribe(res => {
        this.dialogRef.close({ data: res });
        this.submitting = false;
        this.snackBar.open('Storage Updated!', 'Okay!');
      }, () => {
        this.submitting = false;
        this.snackBar.open('Something went wrong!', 'Okay!');
      });
    }
  }

  closeDialog() {
    this.dialogRef.close();
  }

  get address() {
    return this.storageForm.get('address');
  }

  get area() {
    return this.storageForm.get('area');
  }
}
