import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { iRole } from '../role/role.component';
import { ActivatedRoute, RouterLink } from '@angular/router';

@Component({
  selector: 'app-role-view',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './role-view.component.html',
  styleUrl: './role-view.component.css'
})
export class RoleViewComponent {
  id: number = 0;
  role!: iRole;
  constructor(private route: ActivatedRoute, private HttpClient: HttpClient) {
    this.route.params.subscribe((params) => {
      this.id = params['id'];
      if (this.id > 0) {
        this.HttpClient.get<iRole>(
          'https://localhost:44302/Role/GetRole?id=' + this.id,
        ).subscribe((response:iRole) => {
          this.role = response;
          console.log(this.role);
        });
      }
    });
  }
}
