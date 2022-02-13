import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MovieDetailComponent } from './detail/movie-detail.component';
import { MoviesComponent } from './movies.component';

const routes: Routes = [
  {path: '', component: MoviesComponent},
  {path: ':id', component: MovieDetailComponent}
]
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class MoviesRoutingModule { }
