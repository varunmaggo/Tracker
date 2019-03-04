import { Component, OnInit } from '@angular/core';
import { TaskModel } from '../../models/TaskModel';
import { TaskService } from '../../services/taskService';
import { Router } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  tasks: Array<TaskModel>;
  task: TaskModel;
  errorMessage: string;

  constructor(private router: Router, private taskService: TaskService) { }

  ngOnInit() {
    this.getTasks();
    this.task = new TaskModel();
  }

  saveTask(item: TaskModel){
    if (item){
      this.router.navigate(['tasks/upsert/' + item.Id_Task, {task: item} ]);
    } else {
      this.router.navigateByUrl('tasks/upsert');
    }
  }
  
  getTasks() {
    this.taskService.getAllTasks().then(
        tasks => this.tasks = tasks,
        error => this.errorMessage = <any>error
    );
  }

  

}


