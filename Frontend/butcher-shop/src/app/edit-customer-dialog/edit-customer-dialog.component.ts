import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CustomerService } from '../services/customerService/customer.service';

@Component({
  selector: 'app-edit-customer-dialog',
  templateUrl: './edit-customer-dialog.component.html',
  styleUrls: ['./edit-customer-dialog.component.css']
})
export class EditCustomerDialogComponent implements OnInit {
  customerForm: FormGroup;
  submitting = false;

  constructor (
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public customer,
    public dialogRef: MatDialogRef<EditCustomerDialogComponent>,
    private snackBar: MatSnackBar,
    private customerService: CustomerService
  ) { }

  ngOnInit(): void {
    this.customerForm = this.formBuilder.group({
      name: [
        this.customer.name,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(32),
        ]
      ],
      lastname: [
        this.customer.lastname,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(64),
        ]
      ],
      address: [
        this.customer.address,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(64),
        ]
      ],
      sex: [
        this.customer.sex === true ? true : false,
        Validators.required
      ]
    });
  }

  handleSubmit(form) {
    this.submitting = true;
    let sex = false;
    
    if(form.value.sex === 'true' || form.value.sex === true) {
      sex = true;
    }

    const customer = {...form.value, sex: sex}

    if(this.customer.new) {
      this.customerService.CreteCustomer(this.customer.butcherStoreId, this.customer.articleId, customer)
      .subscribe(_ => {
        this.dialogRef.close({ data: this.customer.articleId });
        this.submitting = false;
        this.snackBar.open('Article Sold!', 'Okay!');
      }, () => {
        this.submitting = false;
        this.snackBar.open('Something went wrong!', 'Okay!');
      });
    } else {
      this.customerService.UpdateCustomer(this.customer.id, customer)
      .subscribe(res => {
        this.dialogRef.close({ data: res });
        this.snackBar.open('Customer Updated!', 'Okay!');
        this.submitting = false;
      }, () => {
        this.snackBar.open('Something went wrong!', 'Okay!');
        this.submitting = false;
      });
    }
  }

  closeDialog() {
    this.dialogRef.close();
  }

  get name() {
    return this.customerForm.get('name');
  }

  get lastname() {
    return this.customerForm.get('lastname');
  }
  
  get address() {
    return this.customerForm.get('address');
  }

  get sex() {
    return this.customerForm.get('sex');
  }
}
