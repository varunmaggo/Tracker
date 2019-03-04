import { TaskService } from "../../../services/taskService";
import { TaskModel } from "../../../models/TaskModel";
import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "../../../../../node_modules/@angular/router";

@Component({
    selector: 'app-tasks',
    templateUrl: './task-upsert.component.html'
})
export class TaskUpsertComponent implements OnInit{
    task: TaskModel;
    errorMessage: string;
    
    constructor(private router: Router, private taskService: TaskService, private route: ActivatedRoute) {
        this.route.params.subscribe(params => {
            console.log(params);
            if (params['task']) {
                this.task = params['task'];
                this.addTask();
            }
        });
    }
    
    ngOnInit(){}
    
    addTask() {
        console.log(this.task);
        this.taskService.saveTask(this.task).then(
            success => {
                this.errorMessage = 'Task ' + this.task.Name + ' added';
            },
            error => {
                this.errorMessage = 'There was a problem';
            }
        );
    }

}

