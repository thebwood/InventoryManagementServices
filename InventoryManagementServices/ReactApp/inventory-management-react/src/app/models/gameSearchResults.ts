import { UndoRounded } from "@mui/icons-material";

export interface GameSearchResults
{
    id?: string;
    title: string;
    description: string;
    gameRating: string;
}


export class GameSearchResults implements GameSearchResults {
    constructor(init?: GameSearchResultsFormValues) {
        Object.assign(this, init);
    }
}

  export class GameSearchResultsFormValues {
    id?: string = undefined;
    title: string = '';
    description: string= '';
    gameRating: string= '';

    constructor(game?: GameSearchResultsFormValues) {
      if (game) {
        this.id = game.id
        this.title = game.title;
        this.description = game.description;
        this.gameRating = game.gameRating;

      }
    }
  }
