import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  constructor(public oidcSecurityService: OidcSecurityService) {}

  hubConnection: signalR.HubConnection | undefined;

  startConnection = (token: string) => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7001/chat', {
        accessTokenFactory: () => token,
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets,
      })
      .build();

    this.hubConnection
      .start()
      .then(() => {
        console.log('Connection to serverr started');
      })
      .catch((err) => {
        console.log('Error signalR', err);
      });
  };

  sendMessage = (userName: string, message: string) => {
    this.hubConnection?.invoke('SendMessageAsync', userName, message);
  };
  addMessageListener = () => {
    this.hubConnection?.on('SendMessageAsync', (username, message) => {
      console.log(username, message);
    });
  };
}
