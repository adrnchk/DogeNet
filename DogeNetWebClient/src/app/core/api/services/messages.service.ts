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

import { EditMessageModel } from '../models/edit-message-model';
import { SendMessageModel } from '../models/send-message-model';

@Injectable({
  providedIn: 'root',
})
export class MessagesService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiMessagesGetMessagesIdGet
   */
  static readonly ApiMessagesGetMessagesIdGetPath = '/api/Messages/GetMessages/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiMessagesGetMessagesIdGet()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiMessagesGetMessagesIdGet$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, MessagesService.ApiMessagesGetMessagesIdGetPath, 'get');
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
   * To access the full response (for headers, for example), `apiMessagesGetMessagesIdGet$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiMessagesGetMessagesIdGet(params: {
    id: number;
  }): Observable<void> {

    return this.apiMessagesGetMessagesIdGet$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiMessagesSendMessagePost
   */
  static readonly ApiMessagesSendMessagePostPath = '/api/Messages/SendMessage';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiMessagesSendMessagePost()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiMessagesSendMessagePost$Response(params?: {
    body?: SendMessageModel
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, MessagesService.ApiMessagesSendMessagePostPath, 'post');
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
   * To access the full response (for headers, for example), `apiMessagesSendMessagePost$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiMessagesSendMessagePost(params?: {
    body?: SendMessageModel
  }): Observable<void> {

    return this.apiMessagesSendMessagePost$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiMessagesEditMessageIdPut
   */
  static readonly ApiMessagesEditMessageIdPutPath = '/api/Messages/EditMessage/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiMessagesEditMessageIdPut()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiMessagesEditMessageIdPut$Response(params: {
    id: string;
    body?: EditMessageModel
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, MessagesService.ApiMessagesEditMessageIdPutPath, 'put');
    if (params) {
      rb.path('id', params.id, {});
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
   * To access the full response (for headers, for example), `apiMessagesEditMessageIdPut$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiMessagesEditMessageIdPut(params: {
    id: string;
    body?: EditMessageModel
  }): Observable<void> {

    return this.apiMessagesEditMessageIdPut$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiMessagesDeleteMessageIdDelete
   */
  static readonly ApiMessagesDeleteMessageIdDeletePath = '/api/Messages/DeleteMessage/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiMessagesDeleteMessageIdDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiMessagesDeleteMessageIdDelete$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, MessagesService.ApiMessagesDeleteMessageIdDeletePath, 'delete');
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
   * To access the full response (for headers, for example), `apiMessagesDeleteMessageIdDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiMessagesDeleteMessageIdDelete(params: {
    id: number;
  }): Observable<void> {

    return this.apiMessagesDeleteMessageIdDelete$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
