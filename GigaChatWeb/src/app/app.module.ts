import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgxMapLibreGLModule } from '@maplibre/ngx-maplibre-gl';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MapComponent } from './components/map/map.component';
import { VideoMessageComponent } from './components/video-message/video-message.component';
import { PostComponent } from './components/post/post.component';
import { SigninPageComponent } from './pages/signin-page/signin-page.component';
import { SignupPageComponent } from './pages/signup-page/signup-page.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { MapPageComponent } from './pages/map-page/map-page.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './interceptoors/auth.interceptor';
import { SigninFormComponent } from './components/signin-form/signin-form.component';
import { FormsModule } from '@angular/forms';
import { AuthClassDirective } from './directives/auth-class.directive';
import { SignupFormComponent } from './components/signup-form/signup-form.component';

@NgModule({
  declarations: [
    AppComponent,
    MapComponent,
    VideoMessageComponent,
    PostComponent,
    SigninPageComponent,
    SignupPageComponent,
    NavbarComponent,
    MapPageComponent,
    SigninFormComponent,
    SignupFormComponent,
    AuthClassDirective,
  ],
  imports: [BrowserModule, AppRoutingModule, NgxMapLibreGLModule, FormsModule, HttpClientModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
