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

import { AddFriendModel } from '../models/add-friend-model';
import { BlackListDetailsModel } from '../models/black-list-details-model';
import { DeleteFriendModel } from '../models/delete-friend-model';
import { FriendRequestsDetailsModel } from '../models/friend-requests-details-model';
import { FriendsDetailsModel } from '../models/friends-details-model';

@Injectable({
  providedIn: 'root',
})
export class FriendService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiFriendGetFriendsIdGet
   */
  static readonly ApiFriendGetFriendsIdGetPath = '/api/Friend/GetFriends/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiFriendGetFriendsIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFriendGetFriendsIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Array<FriendsDetailsModel>>> {

    const rb = new RequestBuilder(this.rootUrl, FriendService.ApiFriendGetFriendsIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<FriendsDetailsModel>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiFriendGetFriendsIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFriendGetFriendsIdGet$Plain(params: {
    id: number;
  }): Observable<Array<FriendsDetailsModel>> {

    return this.apiFriendGetFriendsIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<FriendsDetailsModel>>) => r.body as Array<FriendsDetailsModel>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiFriendGetFriendsIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFriendGetFriendsIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Array<FriendsDetailsModel>>> {

    const rb = new RequestBuilder(this.rootUrl, FriendService.ApiFriendGetFriendsIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<FriendsDetailsModel>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiFriendGetFriendsIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFriendGetFriendsIdGet$Json(params: {
    id: number;
  }): Observable<Array<FriendsDetailsModel>> {

    return this.apiFriendGetFriendsIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<FriendsDetailsModel>>) => r.body as Array<FriendsDetailsModel>)
    );
  }

  /**
   * Path part for operation apiFriendGetFriendRequestsIdGet
   */
  static readonly ApiFriendGetFriendRequestsIdGetPath = '/api/Friend/GetFriendRequests/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiFriendGetFriendRequestsIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFriendGetFriendRequestsIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Array<FriendRequestsDetailsModel>>> {

    const rb = new RequestBuilder(this.rootUrl, FriendService.ApiFriendGetFriendRequestsIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<FriendRequestsDetailsModel>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiFriendGetFriendRequestsIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFriendGetFriendRequestsIdGet$Plain(params: {
    id: number;
  }): Observable<Array<FriendRequestsDetailsModel>> {

    return this.apiFriendGetFriendRequestsIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<FriendRequestsDetailsModel>>) => r.body as Array<FriendRequestsDetailsModel>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiFriendGetFriendRequestsIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFriendGetFriendRequestsIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Array<FriendRequestsDetailsModel>>> {

    const rb = new RequestBuilder(this.rootUrl, FriendService.ApiFriendGetFriendRequestsIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<FriendRequestsDetailsModel>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiFriendGetFriendRequestsIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFriendGetFriendRequestsIdGet$Json(params: {
    id: number;
  }): Observable<Array<FriendRequestsDetailsModel>> {

    return this.apiFriendGetFriendRequestsIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<FriendRequestsDetailsModel>>) => r.body as Array<FriendRequestsDetailsModel>)
    );
  }

  /**
   * Path part for operation apiFriendGetBlackListIdGet
   */
  static readonly ApiFriendGetBlackListIdGetPath = '/api/Friend/GetBlackList/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiFriendGetBlackListIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFriendGetBlackListIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Array<BlackListDetailsModel>>> {

    const rb = new RequestBuilder(this.rootUrl, FriendService.ApiFriendGetBlackListIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<BlackListDetailsModel>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiFriendGetBlackListIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFriendGetBlackListIdGet$Plain(params: {
    id: number;
  }): Observable<Array<BlackListDetailsModel>> {

    return this.apiFriendGetBlackListIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<BlackListDetailsModel>>) => r.body as Array<BlackListDetailsModel>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiFriendGetBlackListIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFriendGetBlackListIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Array<BlackListDetailsModel>>> {

    const rb = new RequestBuilder(this.rootUrl, FriendService.ApiFriendGetBlackListIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<BlackListDetailsModel>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiFriendGetBlackListIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFriendGetBlackListIdGet$Json(params: {
    id: number;
  }): Observable<Array<BlackListDetailsModel>> {

    return this.apiFriendGetBlackListIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<BlackListDetailsModel>>) => r.body as Array<BlackListDetailsModel>)
    );
  }

  /**
   * Path part for operation apiFriendAddFriendPost
   */
  static readonly ApiFriendAddFriendPostPath = '/api/Friend/AddFriend';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiFriendAddFriendPost()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiFriendAddFriendPost$Response(params?: {
    body?: AddFriendModel
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, FriendService.ApiFriendAddFriendPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiFriendAddFriendPost$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiFriendAddFriendPost(params?: {
    body?: AddFriendModel
  }): Observable<void> {

    return this.apiFriendAddFriendPost$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiFriendDeleteFriendDelete
   */
  static readonly ApiFriendDeleteFriendDeletePath = '/api/Friend/DeleteFriend';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiFriendDeleteFriendDelete()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiFriendDeleteFriendDelete$Response(params?: {
    body?: DeleteFriendModel
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, FriendService.ApiFriendDeleteFriendDeletePath, 'delete');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiFriendDeleteFriendDelete$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiFriendDeleteFriendDelete(params?: {
    body?: DeleteFriendModel
  }): Observable<void> {

    return this.apiFriendDeleteFriendDelete$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
