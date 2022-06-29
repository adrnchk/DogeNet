import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable({
  providedIn: 'root',
})
export class TokenInterceptorService implements HttpInterceptor {
  constructor(public oidcSecurityService: OAuthService) {}
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    let token = this.oidcSecurityService.getAccessToken();
    let tokenizedReq = req.clone({
      setHeaders: {
        Authorization: 'Bearer ' + token,
      },
    });
    return next.handle(tokenizedReq);
  }
}
