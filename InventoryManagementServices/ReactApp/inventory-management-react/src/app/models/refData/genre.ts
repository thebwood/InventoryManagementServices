export interface Genres{
    id?: string;
    description?: string;

}

export class Genres implements Genres {
    constructor(init?: Genres) {
        Object.assign(this, init);
    }
}