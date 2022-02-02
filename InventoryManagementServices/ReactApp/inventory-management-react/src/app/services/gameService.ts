import agent from "../api/agent";
import { Game } from "../models/games/game";
import { GameSearch } from "../models/games/gameSearch";

export default class GameService {
    searchGames = async (GameSearchFields: GameSearch) => {
        try {
            return await agent.Games.search(GameSearchFields);
        } 
        catch (error) {
            console.log(error);
        }

    }
    loadGames = async () => {
        try {
            return await agent.Games.list();
        } 
        catch (error) {
            console.log(error);
        }
    }

    loadGame = async (id: string) => {
        try {
            return await agent.Games.details(id);
        } 
        catch (error) {
            console.log(error);
        }
    }

    loadGameRatings = async () =>{
        try {
            return await agent.Games.gameRatings();
        } 
        catch (error) {
            console.log(error);
        }
    }
    saveGame = async (game: Game) => {
        try {
            return await agent.Games.save(game);
        } 
        catch (error) {
            console.log(error);
        }
    }
}