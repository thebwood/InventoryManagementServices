export interface MovieRatings{
    id?: string;
    rating?: string;
    //age?: number;
}

export class MovieRatings implements MovieRatings {
    constructor(init?: MovieRatings) {
        Object.assign(this, init);
    }
}