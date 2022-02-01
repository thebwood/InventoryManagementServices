export interface Movie{
    id: string;
    title: string;
    date: Date | null;
    description: string;
    movieRatingsId: string;
    category: string;
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
    date: Date | null = null;
    movieRatingsId: string = '';

    constructor(movie?: MovieFormValues) {
      if (movie) {
        this.id = movie.id;
        this.title = movie.title;
        this.category = movie.category;
        this.description = movie.description;
        this.date = movie.date;
        this.movieRatingsId = movie.movieRatingsId;
      }
    }
  }