import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
//import { HomePageComponent } from './home-page/home-page.component';
import { DoctorComponent } from './doctor/doctor.component';
import { AddEditComponent } from './doctor/add-edit/add-edit.component';
import { ShowComponent } from './doctor/show/show.component';
import {SharedService} from './shared.service';

import {HttpClientModule} from '@angular/common/http';

import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HomepageComponent } from './homepage/homepage.component'; 
@NgModule({
  declarations: [
    AppComponent,
    //HomePageComponent,
    DoctorComponent,
    AddEditComponent,
    ShowComponent,
    HomepageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
