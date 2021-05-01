import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from "@angular/forms";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  passwordVisible = false;
  repeatPasswordVisible = false;
  passwordValue = '';

  constructor(private formBuilder: FormBuilder) {
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
      repeatPassword: [
        '',
        [
          Validators.required,
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

  get repeatPassword() {
    return this.registerForm.get('repeatPassword');
  }

  get terms() {
    return this.registerForm.get('terms');
  }
}
