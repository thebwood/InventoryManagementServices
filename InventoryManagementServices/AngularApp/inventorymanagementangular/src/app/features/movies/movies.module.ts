import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MovieDetailComponent } from './detail/movie-detail.component';
import { MoviesComponent } from './movies.component';
import { MoviesRoutingModule } from './movies-routing.module';




@NgModule({
  declarations: [MoviesComponent, MovieDetailComponent],
  imports: [
    CommonModule,
    MoviesRoutingModule
  ],
  exports: [MoviesComponent]
})
export class MoviesModule { }
