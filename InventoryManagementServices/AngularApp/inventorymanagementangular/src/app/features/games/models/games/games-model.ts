export interface IGamesModel {
    id?: string;
    title: string;
    description: string;
    gameRating: string;
    
}

export class GamesModel implements IGamesModel {
    title: string = "";
    description: string = "";
    gameRating: string = "";
}
