import React, { Fragment, useEffect, useState } from "react";
import { Game } from "../../app/models/games/game";
import { GameRatings } from "../../app/models/games/gameRatings";
import { GameSearch } from "../../app/models/games/gameSearch";
import { GameSearchResults } from "../../app/models/games/gameSearchResults";
import { useService } from "../../app/services/services";
import GameSearchForm from "./components/gameSearchForm";
import GamesGrid from "./components/gamesGrid";


const Games: React.FC = () => {
    const [games, setGames] = useState<GameSearchResults[]>([]);
    const [gameRatings, setGameRatings] = useState<GameRatings[]>([]);
    const {gameService} = useService();
    const { loadGameRatings, searchGames} = gameService;

    useEffect(() => {
        loadGameRatings().then(gameRatingsList => {
            if (gameRatingsList)
                setGameRatings(gameRatingsList);
        });

        searchGames(new GameSearch()).then(gamesList =>{
            if(gamesList)
                setGames(gamesList);
        });
    }, [loadGameRatings, searchGames]); 

    const searchGamesList = (gameSearchFields: GameSearch) =>{
        searchGames(gameSearchFields).then(gamesList =>{
            if(gamesList)
                setGames(gamesList);
        });

    }


    return (
        <Fragment>
            <h1>Games</h1>
            <GameSearchForm GameRatingsList={gameRatings} HandleSearch={ searchGamesList }></GameSearchForm>
            <GamesGrid Games={games}></GamesGrid>
        </Fragment>
    );
};

export default Games;