import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../../_models/user';
import { AlertifyService } from '../../_services/alertify.service';
import { AuthService } from '../../_services/auth.service';
import { UserService } from '../../_services/user.service';

@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html',
  styleUrls: ['./user-add.component.css']
})
export class UserAddComponent implements OnInit {
  user: User;
  registerForm: FormGroup;

  constructor(private authService: AuthService,
    private userService: UserService,
    private alertify: AlertifyService,
    private fb: FormBuilder,
    private router: Router) { }

    ngOnInit(): void {
      this.createRegisterForm();
    }

  createRegisterForm(){
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(15)]],
      firstName: [''],
      LastName: [''],
    });
  }

  addNew(){
    if (this.registerForm.valid){
      this.user = Object.assign({}, this.registerForm.value);
      this.authService.register(this.user)
        .subscribe(() => {
          this.alertify.success('New user added!');
          this.router.navigate(['/user-list']);
        }, error => {
          this.alertify.error(error);
        });
    }
  }

}
