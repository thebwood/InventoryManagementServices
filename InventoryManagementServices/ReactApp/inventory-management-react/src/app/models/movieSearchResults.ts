import { UndoRounded } from "@mui/icons-material";

export interface MovieSearchResults
{
    id?: string;
    title: string;
    description: string;
    movieRating: string;
    moveGenre: string;
    hours?: string;
    minutes?: string;
    boxOffice?: string;

}


export class MovieSearchResults implements MovieSearchResults {
    constructor(init?: MovieSearchResultsFormValues) {
        Object.assign(this, init);
    }
}

  export class MovieSearchResultsFormValues {
    id?: string = undefined;
    title: string = '';
    description: string= '';
    movieRating: string= '';
    moveGenre: string = '';
    hours?: string = undefined;
    minutes?: string = undefined;
    boxOffice?: string = undefined;

    constructor(movie?: MovieSearchResultsFormValues) {
      if (movie) {
        this.id = movie.id
        this.title = movie.title;
        this.description = movie.description;
        this.movieRating = movie.movieRating;
        this.moveGenre = movie.moveGenre;
        this.hours = movie.hours;
        this.minutes = movie.minutes;
        this.boxOffice = movie.boxOffice;
      }
    }
  }
