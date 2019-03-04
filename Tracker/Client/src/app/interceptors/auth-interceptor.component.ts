import { Observable } from 'rxjs/Observable';
//import { AuthService } from '../auth/authService';
import { Injectable, Injector } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import 'rxjs/add/operator/do';
import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthHttpInterceptor implements HttpInterceptor {
  //private authService: AuthService,
  constructor( private injector: Injector, private authService:AuthService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    req = req.clone();
    var headers = req.headers.append('Authorization', `Bearer ${this.authService.getToken()}`);
    req = req.clone({
      headers : headers
    });

    return next.handle(req).do((evet: HttpEvent<any>) => {

    }, (err: any) => {
      if (err instanceof HttpErrorResponse) {
        if (err.status === 401 || err.status === 403) {
          // redirect login
          this.authService.logout();
        }

        //if (err.status === 503) {
        //  location.reload();
        //}
      }
    });
  }
}
