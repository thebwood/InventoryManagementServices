import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IGamesModel } from '../models/games/games-model';
import { GameService } from '../services/game.service';

@Component({
  selector: 'app-game-detail',
  templateUrl: './game-detail.component.html',
  styleUrls: ['./game-detail.component.scss']
})
export class GameDetailComponent implements OnInit {
  game: IGamesModel = {
    description: "",
    title: "",
    gameRating: ""
  };

  constructor(private gameService: GameService,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getGame()
  }

  getGame() {
    this.gameService.getGame(this.route.snapshot.paramMap.get('id') ?? "").subscribe(game => {
      this.game = game;
    }, error => {
      console.log(error);
    });
  }
}
