import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
// import { ToasterService } from 'angular2-toaster';
@Component({
  selector: 'clocking-cmp',
  templateUrl: './clocking.component.html',
  styleUrls: ['./clocking.component.css']
})
export class ClockingComponent implements OnInit {
  ngOnInit(): void {
  }
}
