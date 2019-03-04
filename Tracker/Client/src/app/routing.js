"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var tasks_component_1 = require("./components/tasks/tasks.component");
var login_component_1 = require("./components/login/login.component");
var task_groups_component_1 = require("./components/task-groups/task-groups.component");
var taskGroups_insert_component_1 = require("./components/task-groups/insert/taskGroups-insert.component");
var task_upsert_component_1 = require("./components/tasks/upsert/task-upsert.component");
exports.appRoutes = [
    { path: 'tasks', component: tasks_component_1.TasksComponent },
    { path: 'tasks/upsert/:id', component: task_upsert_component_1.TaskUpsertComponent },
    { path: 'login', component: login_component_1.LoginComponent },
    { path: 'taskGroups', component: task_groups_component_1.TaskGroupsComponent },
    { path: 'taskGroups/insert', component: taskGroups_insert_component_1.TaskGroupsInsertComponent },
    { path: 'taskGroups/insert/:id', component: taskGroups_insert_component_1.TaskGroupsInsertComponent },
    {
        path: '',
        redirectTo: 'tasks',
        pathMatch: 'full'
    },
    { path: '**', component: login_component_1.LoginComponent }
];
//# sourceMappingURL=routing.js.map