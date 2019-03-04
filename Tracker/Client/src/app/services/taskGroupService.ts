import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TaskGroup, TaskGroup_Filter } from '../models/TaskGroup';


@Injectable()
export class TaskGroupService{
    constructor(private http: HttpClient){}
    
    getById(id:number) {
        return this.http.get<TaskGroup>('/api/taskgroups/getbyid?id=' + id).toPromise();
  }
  getAllTaskGroups(filter: TaskGroup_Filter) {
    return this.http.get<TaskGroup[]>('/api/taskGroups/GetTaskGroups?filter=' + JSON.stringify(filter)).toPromise();
    }

    saveTaskGroup(group: TaskGroup){
        return this.http.post<TaskGroup>('/api/taskGroups/AddTaskGroup', group).toPromise();
    }

    delete(item:TaskGroup) {
        return this.http.delete('/api/taskGroups/delete?id=' + item.Id_TaskGroupModel).toPromise();
    }
}
