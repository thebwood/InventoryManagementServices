export interface MovieSearch
{
    title?: string;
    description?: string;
    releaseYear?: string;
    movieRatingsId?: string;
    movieGenreIds?: [];
}


export class MovieSearch implements MovieSearch {
    constructor(init?: MovieSearchFormValues) {
        Object.assign(this, init);
    }
}

  export class MovieSearchFormValues {
    title: string = '';
    description: string= '';
    releaseYear: string= '';
    movieRatingsId: string= '';
    movieGenreIds?: [] = undefined;

    constructor(game?: MovieSearchFormValues) {
      if (game) {
        this.title = game.title;
        this.description = game.description;
        this.releaseYear = game.releaseYear;
        this.movieRatingsId = game.movieRatingsId;
        this.movieGenreIds = game.movieGenreIds;
      }
    }
  }
