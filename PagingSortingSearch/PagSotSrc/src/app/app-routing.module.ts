import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CourselistComponent } from './courselist/courselist.component';
import { BcourseComponent } from './bcourse/bcourse.component';

const routes: Routes = [
  {path : '' , redirectTo: '/course' , pathMatch: 'full'},
  {path : 'course' , component : CourselistComponent},
  {path : 'bcourse' , component : BcourseComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
