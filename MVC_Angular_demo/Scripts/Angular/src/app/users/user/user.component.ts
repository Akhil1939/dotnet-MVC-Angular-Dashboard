import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
export interface iUser {
  Id: number;
  FirstName: string;
  LastName: string;
  Email: string;
  Age: number;
}
@Component({
  selector: 'app-user',
  standalone: true,
  imports: [RouterOutlet, CommonModule],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent {

}
