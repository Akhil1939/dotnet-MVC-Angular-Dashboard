import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { iRole } from '../role/role.component';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-role-list',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './role-list.component.html',
  styleUrl: './role-list.component.css',
})
export class RoleListComponent {
  RoleList: iRole[] = [];
  constructor(private HttpClient: HttpClient) {
    this.HttpClient.get<iRole[]>(
      'https://localhost:44302/Role/GetRoles'
    ).subscribe((data) => (this.RoleList = data));
    console.log('role list component');
  }
  NgOnInit() {
  
  }
}
