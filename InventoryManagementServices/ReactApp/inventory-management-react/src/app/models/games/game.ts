export interface Game{
    id?: string;
    title?: string;
    description?: string;
    gameRatingsId?: string;
}

export class Game implements Game {
    constructor(init?: GameFormValues) {
        Object.assign(this, init);
    }
}

  export class GameFormValues {
    id?: string = undefined;
    title: string = '';
    description: string = '';
    gameRatingsId?: string = undefined;

    constructor(game?: GameFormValues) {
      if (game) {
        this.id = game.id;
        this.title = game.title;
        this.description = game.description;
        this.gameRatingsId = game.gameRatingsId;
      }
    }
  }

