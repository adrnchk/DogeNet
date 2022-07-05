import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MessengerModule } from './messenger/messenger.module';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './shared/components/nav-bar/nav-bar.component';
import { MatListModule } from '@angular/material/list';
import { MatBadgeModule } from '@angular/material/badge';
import { MatIconModule } from '@angular/material/icon';
import { HeaderComponent } from './shared/components/header/header.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { ProfileModule } from './profile/profile.module';
import { TokenInterceptorService } from './core/interceptors/token-interceptor.service';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';
import { EffectsModule } from '@ngrx/effects';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { AppEffects } from './app.effects';
import { reducers } from './store/reducers';
import { OAuthModule } from 'angular-oauth2-oidc';
import { LoginComponent } from './shared/components/login/login.component';
import { AuthGuard } from './core/guards/auth.guard';
import { FriendsModule } from './friends/friends.module';
import { GroupsModule } from './groups/groups.module';
import { UserEffects } from './store/effects/user_info.effects';
import { FriendsEffects } from './store/effects/friends.effects';
import { GroupsEffects } from './store/effects/groups.effects';
import { ConversationsEffects } from './store/effects/conversations.effects';
import { MessagesEffects } from './store/effects/messages.effects';

@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent,
    NavBarComponent,
    HeaderComponent,
    LoginComponent,
  ],
  imports: [
    GroupsModule,
    MessengerModule,
    FriendsModule,
    MatMenuModule,
    ProfileModule,
    MatListModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatBadgeModule,
    MatIconModule,
    MatToolbarModule,
    OAuthModule.forRoot(),
    StoreModule.forRoot(reducers, {
      runtimeChecks: {
        strictActionImmutability: true,
        strictStateImmutability: true,
      },
    }),
    StoreDevtoolsModule.instrument({
      maxAge: 25,
      logOnly: environment.production,
    }),
    EffectsModule.forRoot([
      UserEffects,
      FriendsEffects,
      GroupsEffects,
      ConversationsEffects,
      MessagesEffects,
    ]),
    StoreRouterConnectingModule.forRoot(),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true,
    },
    AuthGuard,
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
