import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EmployeeService } from '../services/employeeService/employee-service.service';

@Component({
  selector: 'app-edit-employee-dialog',
  templateUrl: './edit-employee-dialog.component.html',
  styleUrls: ['./edit-employee-dialog.component.css']
})
export class EditEmployeeDialogComponent implements OnInit {
  employeeForm: FormGroup;
  submitting = false;

  constructor(
    private formBuilder: FormBuilder, 
    public dialogRef : MatDialogRef<EditEmployeeDialogComponent>, 
    @Inject(MAT_DIALOG_DATA) public employee, 
    private employeeService: EmployeeService, 
    private snackBar: MatSnackBar
    ) { }
  
  ngOnInit(): void {
    this.employeeForm = this.formBuilder.group({
      name: [
        this.employee.name,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(64),
          Validators.pattern(/^\D{3,16}$/)
        ]
      ],
      lastname: [
        this.employee.lastname,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(64),
          Validators.pattern(/^\D{3,32}$/)
        ]
      ],
      address: [
        this.employee.address,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(64),
        ]
      ],
      job: [
        this.employee.job,
        [
          Validators.required,
        ]
      ],
      sex: [
        this.employee.sex === true ? true : false,
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

    const employee = {...form.value, butcherStoreId: this.employee.butcherStoreId, sex: sex, id: this.employee.id}

    if(this.employee.new) {
      this.employeeService.CreateEmployee(employee)
      .subscribe(res => {
        this.dialogRef.close({ data: res });
        this.snackBar.open('Employee added!', 'Okay!');
        this.submitting = false;
      }, () => {
        this.snackBar.open('Something went wrong!', 'Okay!');
        this.submitting = false;
      });
    } else {
      this.employeeService.UpdateEmployee(this.employee.id, employee)
      .subscribe(res => {
        this.dialogRef.close({ data: res });
        this.snackBar.open('Employee updated!', 'Okay!');
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
    return this.employeeForm.get('name');
  }

  get lastname() {
    return this.employeeForm.get('lastname');
  }
  
  get address() {
    return this.employeeForm.get('address');
  }

  get job() {
    return this.employeeForm.get('job');
  }

  get sex() {
    return this.employeeForm.get('sex');
  }
}
