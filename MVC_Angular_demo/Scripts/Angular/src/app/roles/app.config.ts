import { HttpClient, provideHttpClient } from '@angular/common/http';
import { ApplicationConfig } from '@angular/core';
import { Routes, provideRouter, withComponentInputBinding } from '@angular/router';
import { APP_BASE_HREF } from '@angular/common';
import { RoleListComponent } from './role-list/role-list.component';
import { RoleEditComponent } from './role-edit/role-edit.component';
import { RoleViewComponent } from './role-view/role-view.component';
export const routes: Routes = [
  {path: '', component:RoleListComponent, pathMatch:'full'},
  {path:'Edit/:id', component:RoleEditComponent, pathMatch:'full'},
  {path:'View/:id', component:RoleViewComponent, pathMatch:'full'},
  {path: '**', redirectTo: '/'}
];
export const appConfig: ApplicationConfig = {
  providers: [provideHttpClient(), provideRouter(routes), {provide: APP_BASE_HREF, useValue : '/Role' }, ],
};
