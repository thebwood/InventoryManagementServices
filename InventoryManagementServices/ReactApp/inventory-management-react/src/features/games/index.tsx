import React, { Fragment, useEffect } from "react";
import { Game } from "../../app/models/game";
import { useService } from "../../app/services/services";
import GamesGrid from "./components/gamesGrid";


function Games(){
    const {gameService} = useService();
    const { loadGames} = gameService;

    useEffect(() => {
        loadGames();
    }, [loadGames]); 


    return (
        <Fragment>
            <h1>Games</h1>
            <GamesGrid Games={gameService.games}></GamesGrid>
        </Fragment>
    );
};

export default Games;