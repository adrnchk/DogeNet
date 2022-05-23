import { Injectable } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { SelectMultipleControlValueAccessor } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class TokenInterceptorService implements HttpInterceptor {
  constructor(public oidcSecurityService: OidcSecurityService) {}
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    let tokenResult = '';
    const res = this.oidcSecurityService.getAccessToken().subscribe((token) => {
      tokenResult = token ?? '';
    });
    let tokenizedReq = req.clone({
      setHeaders: {
        Authorization: 'Bearer ' + tokenResult,
      },
    });
    return next.handle(tokenizedReq);
  }
}
