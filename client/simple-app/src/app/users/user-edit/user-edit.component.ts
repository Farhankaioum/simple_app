import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../../_models/user';
import { AlertifyService } from '../../_services/alertify.service';
import { AuthService } from '../../_services/auth.service';
import { UserService } from '../../_services/user.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  user: User;
  registerForm: FormGroup;

  constructor(private authService: AuthService,
    private userService: UserService,
    private alertify: AlertifyService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.user = data.user;
    });
    this.createRegisterForm();
  }

  createRegisterForm(){
    this.registerForm = this.fb.group({
      email: [this.user.email, [Validators.required, Validators.email]],
      password: [''],
      firstName: [this.user.firstName],
      lastName: [this.user.lastName],
    });
  }

  updateUser(){
    if (this.registerForm.valid){
      var userId = this.user.id;
      this.user = Object.assign({}, this.registerForm.value);
      this.user.id = userId;
      this.userService.updateUser(userId, this.user)
        .subscribe(() => {
          this.alertify.success('Update user information!');
          this.router.navigate(['/user-list']);
        }, error => {
          this.alertify.error(error);
        });
    }
  }

}
