import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { iUser } from '../user/user.component';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent {
  userList: iUser[] = [];
  constructor(private http: HttpClient) {
    console.log('init');
    this.http
      .get<iUser[]>('https://localhost:44302/User/UserList')
      .subscribe((data) => {
        this.userList = data;
      });
  }
}
