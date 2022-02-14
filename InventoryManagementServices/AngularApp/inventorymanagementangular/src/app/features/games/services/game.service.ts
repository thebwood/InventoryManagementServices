import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IGamesModel } from '../models/games/games-model';
import { GameSearchFormModel } from '../models/gameSearchForm/game-search-form-model';
import { IGamesGridModel } from '../models/gamesGrid/games-grid-model';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  baseUrl = "http://localhost:5109/api/games/";

  constructor(private http: HttpClient) { }


  searchGames(gameSearch: GameSearchFormModel) {
    return this.http.post<IGamesGridModel[]>(this.baseUrl + 'search', gameSearch);
  }

  getGame(id: String) {
    return this.http.get<IGamesModel>(this.baseUrl + id);
  }
}
