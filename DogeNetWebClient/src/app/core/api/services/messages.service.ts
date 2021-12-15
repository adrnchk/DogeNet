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
import { MessagesDetailsModel } from '../models/messages-details-model';
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
   * To access only the response body, use `apiMessagesGetMessagesIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiMessagesGetMessagesIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Array<MessagesDetailsModel>>> {

    const rb = new RequestBuilder(this.rootUrl, MessagesService.ApiMessagesGetMessagesIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<MessagesDetailsModel>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiMessagesGetMessagesIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiMessagesGetMessagesIdGet$Plain(params: {
    id: number;
  }): Observable<Array<MessagesDetailsModel>> {

    return this.apiMessagesGetMessagesIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<MessagesDetailsModel>>) => r.body as Array<MessagesDetailsModel>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiMessagesGetMessagesIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiMessagesGetMessagesIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Array<MessagesDetailsModel>>> {

    const rb = new RequestBuilder(this.rootUrl, MessagesService.ApiMessagesGetMessagesIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<MessagesDetailsModel>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiMessagesGetMessagesIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiMessagesGetMessagesIdGet$Json(params: {
    id: number;
  }): Observable<Array<MessagesDetailsModel>> {

    return this.apiMessagesGetMessagesIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<MessagesDetailsModel>>) => r.body as Array<MessagesDetailsModel>)
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
   * To access only the response body, use `apiMessagesEditMessageIdPut$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiMessagesEditMessageIdPut$Plain$Response(params: {
    id: string;
    body?: EditMessageModel
  }): Observable<StrictHttpResponse<MessagesDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, MessagesService.ApiMessagesEditMessageIdPutPath, 'put');
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
        return r as StrictHttpResponse<MessagesDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiMessagesEditMessageIdPut$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiMessagesEditMessageIdPut$Plain(params: {
    id: string;
    body?: EditMessageModel
  }): Observable<MessagesDetailsModel> {

    return this.apiMessagesEditMessageIdPut$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<MessagesDetailsModel>) => r.body as MessagesDetailsModel)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiMessagesEditMessageIdPut$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiMessagesEditMessageIdPut$Json$Response(params: {
    id: string;
    body?: EditMessageModel
  }): Observable<StrictHttpResponse<MessagesDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, MessagesService.ApiMessagesEditMessageIdPutPath, 'put');
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
        return r as StrictHttpResponse<MessagesDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiMessagesEditMessageIdPut$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiMessagesEditMessageIdPut$Json(params: {
    id: string;
    body?: EditMessageModel
  }): Observable<MessagesDetailsModel> {

    return this.apiMessagesEditMessageIdPut$Json$Response(params).pipe(
      map((r: StrictHttpResponse<MessagesDetailsModel>) => r.body as MessagesDetailsModel)
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
