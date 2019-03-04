import { Component, OnInit } from '@angular/core';
import { TaskGroupService } from '../../services/taskGroupService';
import { Router, ActivatedRoute } from '@angular/router';
import { TaskGroup, TaskGroup_Filter } from '../../models/TaskGroup';

@Component({
  selector: 'app-task-groups',
  templateUrl: './task-groups.component.html',
  styleUrls: ['./task-groups.component.css']
})

export class TaskGroupsComponent implements OnInit {
  filter: TaskGroup_Filter = new TaskGroup_Filter();
  taskGroups: Array<TaskGroup>;
  taskGroup: TaskGroup;
  errorMessage: string;

  constructor(private router: Router, private taskGroupService: TaskGroupService) { }

  ngOnInit() {
    this.getTaskGroups();
  }

  goBack() {
    this.router.navigateByUrl('/taskGroups');
  }

  getTaskGroups() {
    this.taskGroupService.getAllTaskGroups(this.filter).then(
      taskGroups => this.taskGroups = taskGroups,
      error => this.errorMessage = <any>error
    );
  }

  insertTG(){
    this.router.navigateByUrl('taskGroups/insert');
  }

  edit(item:TaskGroup){
    this.router.navigate(['taskGroups/insert', { id: item.Id_TaskGroupModel }]);
  }

  delete(item:TaskGroup) {

  }
}
