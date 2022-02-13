import { Component, OnInit } from '@angular/core';
import { GameSearchFormModel } from './models/gameSearchForm/game-search-form-model';
import { GamesGridModel, IGamesGridModel } from './models/gamesGrid/games-grid-model';
import { GameService } from './services/game.service';


@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.scss']
})
export class GamesComponent implements OnInit {
  games: IGamesGridModel [] = [];
  gameSearch: GameSearchFormModel = {};

  constructor(private gameService : GameService) { }

  ngOnInit(): void {
    this.searchGames(this.gameSearch);
  }

  searchGames(gameSearch: GameSearchFormModel): void {
    this.gameService.searchGames(gameSearch).subscribe(games => {
      this.games = games;
    }, error => {
      console.log(error);
    });
  }
}
