export interface GameRatings{
    id?: string;
    rating?: string;
    //age?: number;
}

export class GameRatings implements GameRatings {
    constructor(init?: GameRatings) {
        Object.assign(this, init);
    }
}