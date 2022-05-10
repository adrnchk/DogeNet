import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
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
import { AuthModule, LogLevel } from 'angular-auth-oidc-client';

@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent,
    NavBarComponent,
    HeaderComponent,
  ],
  imports: [
    MessengerModule,
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
    AuthModule.forRoot({
      config: {
        authority: 'https://localhost:10001',
        redirectUrl: 'http://localhost:4200',
        postLogoutRedirectUri: window.location.origin,
        clientId: 'DogeNet-web-app',
        scope: 'openid DogeNetWebAPI',
        responseType: 'code',
        silentRenew: true,
        useRefreshToken: true,
        logLevel: LogLevel.Debug,
      },
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
