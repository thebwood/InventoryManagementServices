export interface IMovieSearchFormModel{
    title?: string;
    description?: string;
    releaseYear?: string;
    movieRatingsId?: string;
    movieGenreIds?: [];
}

export class MovieSearchFormModel implements IMovieSearchFormModel {
}
