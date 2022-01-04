/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { AccountDetailsModel } from '../models/account-details-model';

@Injectable({
  providedIn: 'root',
})
export class UserService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiUserGetUserByIdIdGet
   */
  static readonly ApiUserGetUserByIdIdGetPath = '/api/User/GetUserById/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUserGetUserByIdIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUserGetUserByIdIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<AccountDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.ApiUserGetUserByIdIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<AccountDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUserGetUserByIdIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUserGetUserByIdIdGet$Plain(params: {
    id: number;
  }): Observable<AccountDetailsModel> {

    return this.apiUserGetUserByIdIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<AccountDetailsModel>) => r.body as AccountDetailsModel)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUserGetUserByIdIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUserGetUserByIdIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<AccountDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, UserService.ApiUserGetUserByIdIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<AccountDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUserGetUserByIdIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUserGetUserByIdIdGet$Json(params: {
    id: number;
  }): Observable<AccountDetailsModel> {

    return this.apiUserGetUserByIdIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<AccountDetailsModel>) => r.body as AccountDetailsModel)
    );
  }

}
