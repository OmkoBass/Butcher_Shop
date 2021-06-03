import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ButcherService } from '../services/butcherService/butcher-service.service';
import { MatSnackBar } from "@angular/material/snack-bar";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  passwordVisible = false;
  passwordValue = '';
  submitting = false;

  constructor(private formBuilder: FormBuilder, private butcherService: ButcherService, private snackBar: MatSnackBar) {
    this.registerForm = this.formBuilder.group({
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(16),
          Validators.pattern(/^\D{3,16}$/)
        ]
      ],
      username: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(16)
        ]
      ],
      password: [
        this.passwordValue,
        [
          Validators.required,
          Validators.minLength(8),
          Validators.maxLength(64)
        ]
      ],
      terms: [
        false,
        [
          Validators.requiredTrue
        ]
      ]
    });
  }

  ngOnInit(): void {
    this.registerForm.reset();
  }

  get name() {
    return this.registerForm.get('name');
  }

  get username() {
    return this.registerForm.get('username');
  }

  get password() {
    return this.registerForm.get('password');
  }

  get terms() {
    return this.registerForm.get('terms');
  }

  handleRegister(form) {
    this.butcherService.RegisterButcher({
      name: form.value.name,
      username: form.value.username,
      password: form.value.password
    })
    .subscribe(res => {
      this.snackBar.open(`${res.username} account created succesfully!`, 'Okay!');
      this.submitting = false;
    }, () => {
      this.snackBar.open('Something went wrong!', 'Okay!')
      this.submitting = false;
    });
  }
}
