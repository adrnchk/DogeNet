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

import { ConversationDetailsModel } from '../models/conversation-details-model';
import { CreateConversationModel } from '../models/create-conversation-model';

@Injectable({
  providedIn: 'root',
})
export class ConversationService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiConversationGetConversationsIdGet
   */
  static readonly ApiConversationGetConversationsIdGetPath = '/api/Conversation/GetConversations/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiConversationGetConversationsIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiConversationGetConversationsIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Array<ConversationDetailsModel>>> {

    const rb = new RequestBuilder(this.rootUrl, ConversationService.ApiConversationGetConversationsIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ConversationDetailsModel>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiConversationGetConversationsIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiConversationGetConversationsIdGet$Plain(params: {
    id: number;
  }): Observable<Array<ConversationDetailsModel>> {

    return this.apiConversationGetConversationsIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ConversationDetailsModel>>) => r.body as Array<ConversationDetailsModel>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiConversationGetConversationsIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiConversationGetConversationsIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Array<ConversationDetailsModel>>> {

    const rb = new RequestBuilder(this.rootUrl, ConversationService.ApiConversationGetConversationsIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ConversationDetailsModel>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiConversationGetConversationsIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiConversationGetConversationsIdGet$Json(params: {
    id: number;
  }): Observable<Array<ConversationDetailsModel>> {

    return this.apiConversationGetConversationsIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ConversationDetailsModel>>) => r.body as Array<ConversationDetailsModel>)
    );
  }

  /**
   * Path part for operation apiConversationGetConversationByIdIdGet
   */
  static readonly ApiConversationGetConversationByIdIdGetPath = '/api/Conversation/GetConversationById/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiConversationGetConversationByIdIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiConversationGetConversationByIdIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<ConversationDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, ConversationService.ApiConversationGetConversationByIdIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ConversationDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiConversationGetConversationByIdIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiConversationGetConversationByIdIdGet$Plain(params: {
    id: number;
  }): Observable<ConversationDetailsModel> {

    return this.apiConversationGetConversationByIdIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<ConversationDetailsModel>) => r.body as ConversationDetailsModel)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiConversationGetConversationByIdIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiConversationGetConversationByIdIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<ConversationDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, ConversationService.ApiConversationGetConversationByIdIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ConversationDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiConversationGetConversationByIdIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiConversationGetConversationByIdIdGet$Json(params: {
    id: number;
  }): Observable<ConversationDetailsModel> {

    return this.apiConversationGetConversationByIdIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<ConversationDetailsModel>) => r.body as ConversationDetailsModel)
    );
  }

  /**
   * Path part for operation apiConversationCreateConversationPost
   */
  static readonly ApiConversationCreateConversationPostPath = '/api/Conversation/CreateConversation';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiConversationCreateConversationPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiConversationCreateConversationPost$Plain$Response(params?: {
    body?: CreateConversationModel
  }): Observable<StrictHttpResponse<ConversationDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, ConversationService.ApiConversationCreateConversationPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ConversationDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiConversationCreateConversationPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiConversationCreateConversationPost$Plain(params?: {
    body?: CreateConversationModel
  }): Observable<ConversationDetailsModel> {

    return this.apiConversationCreateConversationPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<ConversationDetailsModel>) => r.body as ConversationDetailsModel)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiConversationCreateConversationPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiConversationCreateConversationPost$Json$Response(params?: {
    body?: CreateConversationModel
  }): Observable<StrictHttpResponse<ConversationDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, ConversationService.ApiConversationCreateConversationPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ConversationDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiConversationCreateConversationPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiConversationCreateConversationPost$Json(params?: {
    body?: CreateConversationModel
  }): Observable<ConversationDetailsModel> {

    return this.apiConversationCreateConversationPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<ConversationDetailsModel>) => r.body as ConversationDetailsModel)
    );
  }

}
