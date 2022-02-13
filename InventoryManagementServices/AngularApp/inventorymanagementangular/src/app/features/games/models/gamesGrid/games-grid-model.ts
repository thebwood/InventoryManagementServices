export interface IGamesGridModel {
    id?: string;
    title: string;
    description: string;
    gameRating: string;
}

export class GamesGridModel implements IGamesGridModel {
    title: string = "";
    description: string = "";
    gameRating: string = "";
}
