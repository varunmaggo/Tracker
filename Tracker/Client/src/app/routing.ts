import {Routes, Route} from '@angular/router';
import {TasksComponent} from './components/tasks/tasks.component';
import {LoginComponent} from './components/login/login.component';
import { TaskGroupsComponent } from './components/task-groups/task-groups.component';
import { TaskGroupsInsertComponent } from './components/task-groups/insert/taskGroups-insert.component';
import { TaskUpsertComponent } from './components/tasks/upsert/task-upsert.component';
import { ClockingComponent } from './components/clocking/clocking.component';
import { AuthGuard } from './guards/auth-guard';

export const appRoutes: Routes = [
  { path: 'clocking', component: ClockingComponent, canActivate: [AuthGuard] },
  { path: 'tasks', component: TasksComponent, canActivate: [AuthGuard]},
  { path: 'tasks/upsert/:id', component: TaskUpsertComponent, canActivate: [AuthGuard]},
    { path: 'login', component: LoginComponent },
  { path: 'taskGroups', component: TaskGroupsComponent, canActivate: [AuthGuard]},
  { path: 'taskGroups/insert', component: TaskGroupsInsertComponent, canActivate: [AuthGuard]},
  { path: 'taskGroups/insert/:id', component: TaskGroupsInsertComponent, canActivate: [AuthGuard]},
    {
        path: '',
        redirectTo: 'tasks',
        pathMatch: 'full'
  },
  { path: '**', component: ClockingComponent }

]
