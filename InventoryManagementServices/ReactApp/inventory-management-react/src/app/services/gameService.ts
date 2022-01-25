import agent from "../api/agent";
import { Game } from "../models/game";


export default class GameService {
    games: Game[] = [];

    loadGames = async () => {
        try {
            this.games = await agent.Games.list();
        } 
        catch (error) {
            console.log(error);
        }
    }

}