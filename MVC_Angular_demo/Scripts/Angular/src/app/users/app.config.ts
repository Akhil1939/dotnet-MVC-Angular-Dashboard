import { HttpClient, provideHttpClient } from '@angular/common/http';
import { ApplicationConfig } from '@angular/core';
import { Routes, provideRouter, withComponentInputBinding } from '@angular/router';
import { APP_BASE_HREF } from '@angular/common';
import { UserViewComponent } from './user-view/user-view.component';
import { UserListComponent } from './user-list/user-list.component';

export const routes: Routes = [
  {path: '', component:UserListComponent, pathMatch:'full'},
  {path:'View/:id', component:UserViewComponent, pathMatch:'full'},
  {path: '**', redirectTo: '/'}
];
export const appConfig: ApplicationConfig = {
  providers: [provideHttpClient(), provideRouter(routes), {provide: APP_BASE_HREF, useValue : '/User' }, ],
};
