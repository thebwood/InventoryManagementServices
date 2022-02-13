import { Component, OnInit } from '@angular/core';
import { IMovieGridModel, MovieGridModel } from './models/movieGrid/movie-grid-model';
import { IMovieSearchFormModel, MovieSearchFormModel } from './models/movieSearchForm/movie-search-form-model';
import { MovieService } from './services/movie.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit {
  movies: IMovieGridModel[] = [];
  movieSearch: IMovieSearchFormModel = {};

  constructor(private movieService : MovieService) { }

  ngOnInit(): void {
    this.searchMovies(this.movieSearch);
  }

  searchMovies(movieSearch: MovieSearchFormModel): void {
    this.movieService.searchMovies(movieSearch).subscribe(movies => {
      this.movies = movies;
    }, error => {
      console.log(error);
    });
  }
}
