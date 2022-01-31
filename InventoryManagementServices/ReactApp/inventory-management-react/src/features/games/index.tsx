import React, { Fragment, useEffect, useState } from "react";
import { Game } from "../../app/models/game";
import { GameRatings } from "../../app/models/gameRatings";
import { GameSearch } from "../../app/models/gameSearch";
import { useService } from "../../app/services/services";
import GameSearchForm from "./components/gameSearchForm";
import GamesGrid from "./components/gamesGrid";


const Games: React.FC = () => {
    const [games, setGames] = useState<Game[]>([]);
    const [gameRatings, setGameRatings] = useState<GameRatings[]>([]);
    const {gameService} = useService();
    const {loadGames, loadGameRatings, searhGames} = gameService;

    useEffect(() => {
        loadGameRatings().then(gameRatingsList => {
            if (gameRatingsList)
                setGameRatings(gameRatingsList);
        });

        loadGames().then(gamesList =>{
            if(gamesList)
                setGames(gamesList);
        });
    }, [loadGameRatings, loadGames]); 

    const HandleSearch = (gameSearchFields: GameSearch) =>{
        loadGames().then(gamesList =>{
            if(gamesList)
                setGames(gamesList);
        });

    }


    return (
        <Fragment>
            <h1>Games</h1>
            <GameSearchForm GameRatingsList={gameRatings} HandleSearch={ HandleSearch }></GameSearchForm>
            <GamesGrid Games={games}></GamesGrid>
        </Fragment>
    );
};

export default Games;