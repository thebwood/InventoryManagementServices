import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IMovieModel } from '../models/movie/movie-model';
import { IMovieGridModel } from '../models/movieGrid/movie-grid-model';
import { MovieSearchFormModel } from '../models/movieSearchForm/movie-search-form-model';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  baseUrl = "http://localhost:5091/api/movies/";

  constructor(private http: HttpClient) { }


  searchMovies(movieSearch: MovieSearchFormModel) {
    return this.http.post<IMovieGridModel[]>(this.baseUrl + 'search', movieSearch);
  }

  getMovie(id: String) {
    return this.http.get<IMovieModel>(this.baseUrl + id);
  }
}
