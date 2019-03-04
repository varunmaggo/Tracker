import { Injectable } from '@angular/core';
import { UserModel } from '../models/UserModel';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class AuthService {

    constructor(private http: HttpClient) { }

    isAuthenticated() {
        return this.getUser() != null;
  }

  logout() {
    localStorage.removeItem(environment._tokenKey);
  }


    private getUser() {
        var _user = localStorage.getItem(environment._tokenKey);
        if (_user && _user.length > 0) {
            var user = JSON.parse(_user) as TokenResponse;
            return user;
        } else return null;
    }

    getToken() {
        var token = this.getUser();
        return token != null ? token.access_token : null;
    }

    getRoles() {
        var token = this.getUser();
        if (token != null) {
            return token.roles.split(",");
        } else return [];
    }

    isInRole(role: UserRolesEnum) {
        return this.getRoles().filter(x => x == role) != null;
    }

    makeSignIn() {
        localStorage.removeItem(environment._tokenKey);
        window.location.href = './login';
    }

    // send username and password to authorization API, if successful return token
    authenticate(username: string, password: string) {
        var headers = new HttpHeaders();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');

        return this.http.post('./token', "grant_type=password&username=" + username + "&password=" + password,
            {
                headers: headers
            }).toPromise().then(rsp => {
                var token = rsp as TokenResponse;
                localStorage.setItem(environment._tokenKey, JSON.stringify(token));
                return token;
            });
    }
}

class TokenResponse {
    access_token: string;
    token_type: string;
    expires_in: number;
    roles: string;
}

export enum UserRolesEnum {
    admin = "Admin",
    solider = "Solider"
} 
