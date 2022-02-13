export interface IMovieGridModel {
    id?: string;
    title: string;
    description: string;
    movieRating: string;
    moveGenre: string;
    hours?: string;
    minutes?: string;
    boxOffice?: string;

}

export class MovieGridModel implements IMovieGridModel{
    title: string = "";
    description: string = "";
    movieRating: string = "";
    moveGenre: string = "";
}
