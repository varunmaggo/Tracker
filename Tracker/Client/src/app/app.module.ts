import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routing';
import {FormsModule} from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToasterModule, ToasterService } from 'angular2-toaster';

import { AppComponent } from './app.component';
import { TasksComponent } from './components/tasks/tasks.component';
import { TaskService } from './services/taskService';
import { LoginComponent } from './components/login/login.component';
import { AuthService } from './services/auth.service';
import { TaskGroupsComponent } from './components/task-groups/task-groups.component';
import { TaskGroupService } from './services/taskGroupService';
import { TaskGroupsInsertComponent } from './components/task-groups/insert/taskGroups-insert.component';
import { TaskUpsertComponent } from './components/tasks/upsert/task-upsert.component';
import { ClockingComponent } from './components/clocking/clocking.component';
import { AuthGuard } from './guards/auth-guard';
import { LoginGuard } from './guards/login-guard';
import { AuthHttpInterceptor } from './interceptors/auth-interceptor.component';



@NgModule({
  declarations: [
    AppComponent,
    TasksComponent,
    TaskUpsertComponent,
    LoginComponent,
    TaskGroupsComponent,
    TaskGroupsInsertComponent,
    ClockingComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    BrowserAnimationsModule,
    ToasterModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      multi: true,
      useClass: AuthHttpInterceptor
    },
    TaskService,
    AuthService,
    TaskGroupService,
    ToasterService,
    AuthGuard,
    LoginGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
