import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
export interface iRole{
  Id:number;
  Name:string;
}
@Component({
  selector: 'app-role',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './role.component.html',
  styleUrl: './role.component.css'
})
export class RoleComponent {
  constructor(){
    console.log('role');
  }

}
