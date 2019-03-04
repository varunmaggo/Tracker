import { Component, OnInit } from '@angular/core';
import { TaskGroupService } from '../../../services/taskGroupService';
import { Router, ActivatedRoute } from '@angular/router';
import { TaskGroup } from '../../../models/TaskGroup';
import { ToasterService} from 'angular2-toaster';
 
@Component({
    selector: 'app-task-groups-insert',
    templateUrl: './taskGroups-insert.component.html',
})

export class TaskGroupsInsertComponent implements OnInit {
    taskGroup: TaskGroup;
    id_taskGroup:number = 0;

    constructor(private router: Router,
        private activatedRoute:ActivatedRoute,
         private taskGroupService: TaskGroupService, 
         private toaster:ToasterService) { 
             this.activatedRoute.params.subscribe(params => {
                  this.id_taskGroup = params['id'];
                  if(this.id_taskGroup > 0)
                    this.taskGroupService.getById(this.id_taskGroup).then(rsp => {
                        this.taskGroup = rsp;
                    }, err => {
                        this.toaster.pop('error', err.error);
                    });
             });
         }

    ngOnInit() {
        this.taskGroup = new TaskGroup();
    }

    goBack() {
        this.router.navigateByUrl('/taskGroups');
    }

    addTaskGroup() {
        console.log(this.taskGroup);
        this.taskGroupService.saveTaskGroup(this.taskGroup).then(
          success => {
            this.toaster.pop('success', this.id_taskGroup > 0? 'Task group edited' : 'Task group added.');
               this.goBack();
            },
            error => {
                this.toaster.pop('error', error.error);
            }
        );

    }

}
