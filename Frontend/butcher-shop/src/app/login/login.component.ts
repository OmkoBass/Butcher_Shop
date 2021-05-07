import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ButcherService } from '../services/butcherService/butcher-service.service';
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  passwordVisible = false;
  submitting = false;

  constructor(private formBuilder: FormBuilder, private butcherService: ButcherService, private snackBar: MatSnackBar, private router: Router) {
    this.loginForm = this.formBuilder.group({
      username: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(16)
        ]
      ],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          Validators.maxLength(64),
        ]
      ]
    });
  }

  ngOnInit(): void {
    this.loginForm.reset();
  }

  get username() {
    return this.loginForm.get('username');
  }

  get password() {
    return this.loginForm.get('password');
  }

  handleSubmit(form: FormGroup) {
    this.submitting = true;
    const values = form.value;
    this.butcherService.LoginButcher({username: values.username, password: values.password })
    .subscribe(res => {
      localStorage.setItem('beefyToken', res.token);
      this.router.navigate(['/']);
      this.submitting = false;
    }, (_: Response) => {
      this.snackBar.open('Something went wrong!', 'Okay!')
      this.submitting = false;
    });
  }
}
