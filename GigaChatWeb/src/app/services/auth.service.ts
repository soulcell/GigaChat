import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import jwt_decode, { JwtPayload } from 'jwt-decode';
import User from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  authenticated: boolean = false;
  

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<User> {
    return this.http.post<User>('api/user/login', { username, password })
    .pipe<User>(
      map(result => {
        if (result.token)
          localStorage.setItem('gigachat_token', result.token);
        return result;
      })
    );
  }

  signup(username: string, password: string): Observable<any> {
    return this.http.post('api/user/signup', { username, password });
  }

  getToken(): string | null {
    return localStorage.getItem('gigachat_token');
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    return !!token && !this.isTokenExpired(token);
  }

  isTokenExpired(token: string): boolean {
    const { exp } = jwt_decode<JwtPayload>(token);
    return typeof exp === 'number' && exp < Date.now() / 1000;
  }
}