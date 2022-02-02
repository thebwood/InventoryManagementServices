export interface Movie{
    id: string;
    title: string;
    description: string;
    releaseDate: string | null;
    movieRatingsId: string;
    category: string;
    hours: string | null;
    minutes: string | null;
}

export class Movie implements Movie {
    constructor(init?: MovieFormValues) {
        Object.assign(this, init);
    }
}

  export class MovieFormValues {
    id?: string = undefined;
    title: string = '';
    category: string = '';
    description: string = '';
    releaseDate: string | null = null;
    movieRatingsId: string = '';
    hours: string | null = null;
    minutes: string | null = null;

    constructor(movie?: MovieFormValues) {
      if (movie) {
        this.id = movie.id;
        this.title = movie.title;
        this.category = movie.category;
        this.description = movie.description;
        this.releaseDate = movie.releaseDate;
        this.movieRatingsId = movie.movieRatingsId;
        this.hours = movie.hours;
        this.minutes = movie.minutes;
      }
    }
  }