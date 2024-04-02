import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { iRole } from '../role/role.component';

@Component({
  selector: 'app-role-edit',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './role-edit.component.html',
  styleUrl: './role-edit.component.css',
})
export class RoleEditComponent {
  id: number = 0;
  role!: iRole;
  constructor(private route: ActivatedRoute, private HttpClient: HttpClient) {
    this.route.params.subscribe((params) => {
      this.id = params['id'];
      if (this.id > 0) {
        this.HttpClient.get<iRole>(
          'https://localhost:44302/Role/GetRole'
        ).subscribe((response) => {
          this.role = response;
        });
      }
    });
  }
}
