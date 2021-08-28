import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Permission } from 'src/app/_models/permission';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { SettingService } from 'src/app/_services/setting.service';

@Component({
  selector: 'app-permission',
  templateUrl: './permission.component.html',
  styleUrls: ['./permission.component.css']
})
export class PermissionComponent implements OnInit {
  permissions: Permission[];

  constructor(private route: ActivatedRoute,
              private alertify: AlertifyService,
              private settingService: SettingService) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.route.data.subscribe(data => {
      console.log('data', data);
      this.permissions = data.permissions;
    }, errror => {
      this.alertify.error('Error occured when retrive data!');
    });
  }

  updatePermission(event, id) {
    this.settingService.updatePermission(id, event).subscribe(() => {
      this.alertify.success('permission updated');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.settingService.getPermission().subscribe((data) => {
        this.permissions = data;
      }) 
    });
  }

}
