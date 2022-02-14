
export interface IMovieModel {
    id: string;
    title: string;
    description: string;
    releaseDate: string | null;
    movieRatingsId: string;
    category: string;
    hours: string | null;
    minutes: string | null;
}


export class MovieModel implements IMovieModel {
    title: string = "";
    description: string = "";
    category: string = "";
    id: string = "";
    releaseDate: string | null = null;
    movieRatingsId: string = '';
    hours: string | null = null;
    minutes: string | null = null;

}

