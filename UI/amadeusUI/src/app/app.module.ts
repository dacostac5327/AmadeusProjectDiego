import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { API_BASE_URL, Service } from './amadeus';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { environment } from './environment';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { HomeComponent } from './components/home/home.component';

@NgModule({
  
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent
  ],
  imports: [

    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [{
    provide: API_BASE_URL,
    useValue: environment.apiUrl,
  },Service],
  bootstrap: [AppComponent]
})
export class AppModule { }
