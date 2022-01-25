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

}