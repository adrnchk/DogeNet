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
   * Path part for operation apiConversationIdGet
   */
  static readonly ApiConversationIdGetPath = '/api/Conversation/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiConversationIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiConversationIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<string>> {

    const rb = new RequestBuilder(this.rootUrl, ConversationService.ApiConversationIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<string>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiConversationIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiConversationIdGet$Plain(params: {
    id: number;
  }): Observable<string> {

    return this.apiConversationIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<string>) => r.body as string)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiConversationIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiConversationIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<string>> {

    const rb = new RequestBuilder(this.rootUrl, ConversationService.ApiConversationIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<string>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiConversationIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiConversationIdGet$Json(params: {
    id: number;
  }): Observable<string> {

    return this.apiConversationIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<string>) => r.body as string)
    );
  }

  /**
   * Path part for operation apiConversationPost
   */
  static readonly ApiConversationPostPath = '/api/Conversation';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiConversationPost()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiConversationPost$Response(params?: {
    body?: CreateConversationModel
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, ConversationService.ApiConversationPostPath, 'post');
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
   * To access the full response (for headers, for example), `apiConversationPost$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiConversationPost(params?: {
    body?: CreateConversationModel
  }): Observable<void> {

    return this.apiConversationPost$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
