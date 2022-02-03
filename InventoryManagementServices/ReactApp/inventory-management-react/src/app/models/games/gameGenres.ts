export interface GameGenres{
    id?: string;
    gameId?: string;
    genreDescription?: string;

}

export class GameGenres implements GameGenres {
    constructor(init?: GameGenres) {
        Object.assign(this, init);
    }
}