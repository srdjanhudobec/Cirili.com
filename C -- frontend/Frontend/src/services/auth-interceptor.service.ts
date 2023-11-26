import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { take, exhaustMap } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptorService implements HttpInterceptor{

  constructor(private authService: AuthService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    return this.authService.user.pipe(
      take(1),
      exhaustMap( user => {
        if(!user) {
          return next.handle(req);
        }

        let modifiedReq = req.clone({
          setHeaders: {
            'Authorization' : 'Bearer ' + user.token,
          }
        })

        return next.handle(modifiedReq);
      })
    )
  }
}