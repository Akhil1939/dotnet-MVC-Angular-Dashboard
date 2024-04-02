import { Component } from '@angular/core';
import { iUser } from '../user/user.component';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user-view',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './user-view.component.html',
  styleUrl: './user-view.component.css'
})
export class UserViewComponent {
  id: number = 0;
  user!: iUser;
  constructor(private route: ActivatedRoute, private HttpClient: HttpClient) {
    this.route.params.subscribe((params) => {
      this.id = params['id'];
      if (this.id > 0) {
        this.HttpClient.get<iUser>(
          'https://localhost:44302/User/GetUser?id=' + this.id,
        ).subscribe((response:iUser) => {
          this.user = response;
          console.log(this.user);
        });
      }
    });
  }
}
