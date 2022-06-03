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

import { CreatePostModel } from '../models/create-post-model';
import { EditPostModel } from '../models/edit-post-model';
import { PostDetailsModel } from '../models/post-details-model';

@Injectable({
  providedIn: 'root',
})
export class PostService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiPostGetPostByIdIdGet
   */
  static readonly ApiPostGetPostByIdIdGetPath = '/api/Post/GetPostById/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPostGetPostByIdIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPostGetPostByIdIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<PostDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, PostService.ApiPostGetPostByIdIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<PostDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPostGetPostByIdIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPostGetPostByIdIdGet$Plain(params: {
    id: number;
  }): Observable<PostDetailsModel> {

    return this.apiPostGetPostByIdIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<PostDetailsModel>) => r.body as PostDetailsModel)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPostGetPostByIdIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPostGetPostByIdIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<PostDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, PostService.ApiPostGetPostByIdIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<PostDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPostGetPostByIdIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPostGetPostByIdIdGet$Json(params: {
    id: number;
  }): Observable<PostDetailsModel> {

    return this.apiPostGetPostByIdIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<PostDetailsModel>) => r.body as PostDetailsModel)
    );
  }

  /**
   * Path part for operation apiPostCreatePostPost
   */
  static readonly ApiPostCreatePostPostPath = '/api/Post/CreatePost';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPostCreatePostPost()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiPostCreatePostPost$Response(params?: {
    body?: CreatePostModel
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, PostService.ApiPostCreatePostPostPath, 'post');
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
   * To access the full response (for headers, for example), `apiPostCreatePostPost$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiPostCreatePostPost(params?: {
    body?: CreatePostModel
  }): Observable<void> {

    return this.apiPostCreatePostPost$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiPostEditPostIdPut
   */
  static readonly ApiPostEditPostIdPutPath = '/api/Post/EditPost/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPostEditPostIdPut$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiPostEditPostIdPut$Plain$Response(params: {
    id: string;
    body?: EditPostModel
  }): Observable<StrictHttpResponse<PostDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, PostService.ApiPostEditPostIdPutPath, 'put');
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
        return r as StrictHttpResponse<PostDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPostEditPostIdPut$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiPostEditPostIdPut$Plain(params: {
    id: string;
    body?: EditPostModel
  }): Observable<PostDetailsModel> {

    return this.apiPostEditPostIdPut$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<PostDetailsModel>) => r.body as PostDetailsModel)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPostEditPostIdPut$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiPostEditPostIdPut$Json$Response(params: {
    id: string;
    body?: EditPostModel
  }): Observable<StrictHttpResponse<PostDetailsModel>> {

    const rb = new RequestBuilder(this.rootUrl, PostService.ApiPostEditPostIdPutPath, 'put');
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
        return r as StrictHttpResponse<PostDetailsModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPostEditPostIdPut$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiPostEditPostIdPut$Json(params: {
    id: string;
    body?: EditPostModel
  }): Observable<PostDetailsModel> {

    return this.apiPostEditPostIdPut$Json$Response(params).pipe(
      map((r: StrictHttpResponse<PostDetailsModel>) => r.body as PostDetailsModel)
    );
  }

  /**
   * Path part for operation apiPostDeletePostIdDelete
   */
  static readonly ApiPostDeletePostIdDeletePath = '/api/Post/DeletePost/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPostDeletePostIdDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPostDeletePostIdDelete$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, PostService.ApiPostDeletePostIdDeletePath, 'delete');
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
   * To access the full response (for headers, for example), `apiPostDeletePostIdDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPostDeletePostIdDelete(params: {
    id: number;
  }): Observable<void> {

    return this.apiPostDeletePostIdDelete$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
