import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Store } from '@ngrx/store';
import { OAuthService } from 'angular-oauth2-oidc';
import { MessagesState } from 'src/app/store/states/MessagesState';
import * as MessagesActions from 'src/app/store/actions/messages.action';
import { MessagesDetailsModel } from '../api/models';

@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  constructor(
    public oidcSecurityService: OAuthService,
    private messageStore: Store<MessagesState>
  ) {}

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
        this.messageStore.dispatch(MessagesActions.AddMessage({ message }));
        console.log('Received', user, message);
      });
      connection.on('SystemMessage', (user, message) => {
        console.log('System', user, message);
      });
      connection.on('EditedMessage', (user, message) => {
        this.messageStore.dispatch(MessagesActions.EditMessage({ message }));
        console.log('Edited', user, message);
      });
      connection.on(
        'DeletedMessage',
        (id, user, message: MessagesDetailsModel) => {
          this.messageStore.dispatch(MessagesActions.DeleteMessage({ id }));
          console.log('Deleted', user, message);
        }
      );

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

  sendMessage = async (message: MessagesDetailsModel) => {
    try {
      await this.connection?.invoke('SendMessage', message);
    } catch (e) {
      console.log(e);
    }
  };

  editMessage = async (message: MessagesDetailsModel) => {
    try {
      await this.connection?.invoke('EditMessage', message);
    } catch (e) {
      console.log(e);
    }
  };

  deleteMessage = async (message: MessagesDetailsModel) => {
    try {
      await this.connection?.invoke('DeleteMessage', message);
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
