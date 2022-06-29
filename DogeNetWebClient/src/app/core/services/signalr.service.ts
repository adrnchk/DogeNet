import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  constructor(public oidcSecurityService: OAuthService) {}

  connection: signalR.HubConnection | undefined;
  joinRoom = async (token: string, user: string, room: string) => {
    try {
      const connection = new signalR.HubConnectionBuilder()
        .withUrl('https://localhost:7001/chat', {
          accessTokenFactory: () => token,
          skipNegotiation: true,
          transport: signalR.HttpTransportType.WebSockets,
        })
        .configureLogging(signalR.LogLevel.Information)
        .build();

      connection.on('ReceiveMessage', (user, message) => {
        console.log('Received', user, message);
      });
      connection.on('EditedMessage', (id, user, message) => {
        console.log('Edited', id, user, message);
      });
      connection.on('DeletedMessage', (id, user, message) => {
        console.log('Deleted', id, user, message);
      });

      connection.on('UsersInRoom', (users) => {
        console.log('user in room', user);
      });

      await connection.start();
      await connection.invoke('JoinRoom', { user, room });
      this.connection = connection;
    } catch (e) {
      console.log(e);
    }
  };

  sendMessage = async (message: string) => {
    try {
      await this.connection?.invoke('SendMessage', message);
    } catch (e) {
      console.log(e);
    }
  };

  editMessage = async (id: number, message: string) => {
    try {
      await this.connection?.invoke('EditMessage', id, message);
    } catch (e) {
      console.log(e);
    }
  };

  deleteMessage = async (id: number, message: string) => {
    try {
      await this.connection?.invoke('DeleteMessage', id, message);
    } catch (e) {
      console.log(e);
    }
  };

  closeConnection = async () => {
    try {
      await this.connection?.stop();
    } catch (e) {
      console.log(e);
    }
  };
}
