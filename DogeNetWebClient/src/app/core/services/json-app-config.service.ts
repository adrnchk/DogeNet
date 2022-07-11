import { Injectable } from '@angular/core';
import { HttpClient } from '@aspnet/signalr';

@Injectable({
  providedIn: 'root',
})
export class JsonAppConfigService {
  private appConfig: any;
  constructor(private http: HttpClient) {}

  loadConfig() {
    return this.http.get('/assets/app-config.json').then((data) => {
      this.appConfig = data;
    });
  }

  get apiRootUrl() {
    if (!this.appConfig) {
      throw Error('Config file is not loaded');
    }
    return this.appConfig.apiRootUrl;
  }
}
