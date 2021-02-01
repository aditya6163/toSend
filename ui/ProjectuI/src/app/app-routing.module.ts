import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {DoctorComponent} from './doctor/doctor.component';
import {HomepageComponent} from './homepage/homepage.component';

const routes: Routes = [
  {path:'homepage',component:HomepageComponent},
  {path:'doctor',component:DoctorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
