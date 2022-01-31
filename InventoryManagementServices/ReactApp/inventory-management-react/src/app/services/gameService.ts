import agent from "../api/agent";
import { GameFormValues } from "../models/game";

export default class GameService {
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

    saveGame = async (game: GameFormValues) => {
        try {
            await agent.Games.save(game);
        } 
        catch (error) {
            console.log(error);
        }
    }
}