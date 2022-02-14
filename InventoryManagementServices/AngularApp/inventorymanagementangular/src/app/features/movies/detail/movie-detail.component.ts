import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IMovieModel } from '../models/movie/movie-model';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.scss']
})
export class MovieDetailComponent implements OnInit {
  movie: IMovieModel = {
    description: "",
    title: "",
    id: '',
    releaseDate: null,
    movieRatingsId: '',
    category: '',
    hours: null,
    minutes: null
  };

  constructor(private movieService: MovieService,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getmovie()
  }

  getmovie() {
    this.movieService.getMovie(this.route.snapshot.paramMap.get('id') ?? "").subscribe(movie => {
      this.movie = movie;
    }, error => {
      console.log(error);
    });
  }

}
