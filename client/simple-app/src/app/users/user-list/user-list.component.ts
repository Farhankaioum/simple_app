import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { User } from 'src/app/_models/user';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { UserService } from 'src/app/_services/user.service';
import { AuthService } from 'src/app/_services/auth.service';
import {Router } from '@angular/router';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  users: User[];

  constructor(private alertify: AlertifyService,
    private route: ActivatedRoute,
    private userService: UserService,
    private authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.route.data.subscribe(data => {
      console.log('data', data);
      this.users = data.users;
    }, errror => {
      this.alertify.error('Error occured when retrive data!');
    });
  }

  deleteUser(id) {
    if(confirm("Are you sure to delete")) {
      this.userService.deleteUser(id).subscribe(() => {
        this.alertify.success('Update user information!');
  
      }, error => {
        this.alertify.error(error);
      }, () => {
        this.userService.getUsers().subscribe(data => {
          this.users = data;
        })
      });
    }
  }

}
