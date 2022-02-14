import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MovieDetailComponent } from './detail/movie-detail.component';
import { MoviesComponent } from './movies.component';

const routes: Routes = [
  {path: ':id', component: MovieDetailComponent},
  {path: '', component: MoviesComponent}
]
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class MoviesRoutingModule { }
