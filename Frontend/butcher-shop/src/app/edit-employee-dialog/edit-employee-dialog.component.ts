import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-edit-employee-dialog',
  templateUrl: './edit-employee-dialog.component.html',
  styleUrls: ['./edit-employee-dialog.component.css']
})
export class EditEmployeeDialogComponent implements OnInit {
  employeeForm: FormGroup;

  constructor(private formBuilder: FormBuilder, @Inject(MAT_DIALOG_DATA) public employee) { }

  ngOnInit(): void {
    console.log(this.employee);

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
          Validators.pattern(/^\D{3,64}$/)
        ]
      ],
      job: [
        this.employee.job,
        [
          Validators.required,
        ]
      ],
      sex: [
        this.employee.sex,
        Validators.required
      ]
    });
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
