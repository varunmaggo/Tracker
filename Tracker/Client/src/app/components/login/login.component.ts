import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
// import { ToasterService } from 'angular2-toaster';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: LoginModel = new LoginModel();
  isAuthenticating: boolean = false;
  // constructor(private authService: AuthService, private router: Router, private toaster: ToasterService) { }
  constructor(private authService: AuthService, private router: Router) { }

  // first thing, check if already authenticated, navigate to  home page
  ngOnInit() {
  }

  authenticate(ev) {
    ev.preventDefault();
    //user clicked Login but authentication process already in progress
    //if (this.isAuthenticating) return;

    // check if username not empty
    if (!this.user.username && this.user.username.length == 0) {
      //show error message before exiting
      return;
    }

    // check if password not empty
    if (!this.user.password && this.user.password.length == 0) {
      //show error message before exiting
      return;
    }

    // start the authentification process, call the Authentification service
    // on successful auth, redirect to home page
    // on failed auth, notify user of failure
    this.isAuthenticating = true;
    this.authService.authenticate(this.user.username, this.user.password).then(rsp => {
      // this.toaster.pop("success", "Welcome " + this.user.username);
      this.router.navigateByUrl('/clocking');
    }, err => {
      setTimeout(function () {
        this.isAuthenticating = false;
        // this.toaster.pop("error", "Invalid Login", "Username or password is incorrect");
      }.bind(this), 1000);

    });
  }

  reset() {
    this.user = new LoginModel();
  }
}

class LoginModel {
  username: string = "";
  password: string = "";
}
