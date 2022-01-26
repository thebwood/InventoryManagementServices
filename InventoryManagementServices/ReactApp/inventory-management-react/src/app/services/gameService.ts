import agent from "../api/agent";
import { Game } from "../models/game";


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
}