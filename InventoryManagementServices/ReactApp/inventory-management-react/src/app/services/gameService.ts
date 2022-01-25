import agent from "../api/agent";
import { Game } from "../models/game";
import { GameSearchResults } from "../models/gameSearchResults";

export default class GameService {
    games: Game[] = [];

    loadGames = async () => {
        try {
            this.games = await agent.Games.list();
        } catch (error) {
            console.log(error);

        }
    }

}