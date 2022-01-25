export interface GameSearch
{
    title: string;
    description: string;
    releaseYear: string;
    gameRatingsId: string;
    gameTypeIds?: [];
}


export class GameSearch implements GameSearch {
    constructor(init?: GameSearchFormValues) {
        Object.assign(this, init);
    }
}

  export class GameSearchFormValues {
    title: string = '';
    description: string= '';
    releaseYear: string= '';
    gameRatingsId: string= '';
    gameTypeIds?: [] = undefined;

    constructor(game?: GameSearchFormValues) {
      if (game) {
        this.title = game.title;
        this.description = game.description;
        this.releaseYear = game.releaseYear;
        this.gameRatingsId = game.gameRatingsId;
        this.gameTypeIds = game.gameTypeIds;
      }
    }
  }
