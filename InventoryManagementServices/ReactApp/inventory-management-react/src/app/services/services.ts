import { createContext, useContext } from "react";
import GameService from "./gameService";
import MovieService from "./movieService";

interface Services {
    gameService: GameService;
    movieService: MovieService;
}

export const service: Services = {
    gameService: new GameService(),
    movieService: new MovieService()
}

export const ServiceContext = createContext(service);

export function useService() {
    return useContext(ServiceContext);
}