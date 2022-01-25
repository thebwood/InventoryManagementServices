import { createContext, useContext } from "react";
import GameService from "./GameService";

interface Services {
    gameService: GameService;
}


export const service: Services = {
    gameService: new GameService()
}


export const ServiceContext = createContext(service);

export function useService() {
    return useContext(ServiceContext);
}