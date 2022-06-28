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

import { CreateGroupModel } from '../models/create-group-model';
import { EditGroupModel } from '../models/edit-group-model';
import { GroupDetailsModel } from '../models/group-details-model';

@Injectable({
  providedIn: 'root',
})
export class GroupService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiGroupGetGroupByIdIdGet
   */
  static readonly ApiGroupGetGroupByIdIdGetPath = '/api/Group/GetGroupById/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiGroupGetGroupByIdIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiGroupGetGroupByIdIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<GroupDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, GroupService.ApiGroupGetGroupByIdIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<GroupDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiGroupGetGroupByIdIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiGroupGetGroupByIdIdGet$Plain(params: {
    id: number;
  }): Observable<GroupDetailsModel> {

    return this.apiGroupGetGroupByIdIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<GroupDetailsModel>) => r.body as GroupDetailsModel)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiGroupGetGroupByIdIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiGroupGetGroupByIdIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<GroupDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, GroupService.ApiGroupGetGroupByIdIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<GroupDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiGroupGetGroupByIdIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiGroupGetGroupByIdIdGet$Json(params: {
    id: number;
  }): Observable<GroupDetailsModel> {

    return this.apiGroupGetGroupByIdIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<GroupDetailsModel>) => r.body as GroupDetailsModel)
    );
  }

  /**
   * Path part for operation apiGroupCreateGroupPost
   */
  static readonly ApiGroupCreateGroupPostPath = '/api/Group/CreateGroup';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiGroupCreateGroupPost()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiGroupCreateGroupPost$Response(params?: {
    body?: CreateGroupModel
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, GroupService.ApiGroupCreateGroupPostPath, 'post');
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
   * To access the full response (for headers, for example), `apiGroupCreateGroupPost$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiGroupCreateGroupPost(params?: {
    body?: CreateGroupModel
  }): Observable<void> {

    return this.apiGroupCreateGroupPost$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiGroupEditGroupIdPut
   */
  static readonly ApiGroupEditGroupIdPutPath = '/api/Group/EditGroup/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiGroupEditGroupIdPut$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiGroupEditGroupIdPut$Plain$Response(params: {
    id: string;
    body?: EditGroupModel
  }): Observable<StrictHttpResponse<GroupDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, GroupService.ApiGroupEditGroupIdPutPath, 'put');
    if (params) {
      rb.path('id', params.id, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<GroupDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiGroupEditGroupIdPut$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiGroupEditGroupIdPut$Plain(params: {
    id: string;
    body?: EditGroupModel
  }): Observable<GroupDetailsModel> {

    return this.apiGroupEditGroupIdPut$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<GroupDetailsModel>) => r.body as GroupDetailsModel)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiGroupEditGroupIdPut$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiGroupEditGroupIdPut$Json$Response(params: {
    id: string;
    body?: EditGroupModel
  }): Observable<StrictHttpResponse<GroupDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, GroupService.ApiGroupEditGroupIdPutPath, 'put');
    if (params) {
      rb.path('id', params.id, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<GroupDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiGroupEditGroupIdPut$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiGroupEditGroupIdPut$Json(params: {
    id: string;
    body?: EditGroupModel
  }): Observable<GroupDetailsModel> {

    return this.apiGroupEditGroupIdPut$Json$Response(params).pipe(
      map((r: StrictHttpResponse<GroupDetailsModel>) => r.body as GroupDetailsModel)
    );
  }

  /**
   * Path part for operation apiGroupDeleteGroupIdDelete
   */
  static readonly ApiGroupDeleteGroupIdDeletePath = '/api/Group/DeleteGroup/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiGroupDeleteGroupIdDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiGroupDeleteGroupIdDelete$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, GroupService.ApiGroupDeleteGroupIdDeletePath, 'delete');
    if (params) {
      rb.path('id', params.id, {});
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
   * To access the full response (for headers, for example), `apiGroupDeleteGroupIdDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiGroupDeleteGroupIdDelete(params: {
    id: number;
  }): Observable<void> {

    return this.apiGroupDeleteGroupIdDelete$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
