import React, { Fragment, useEffect, useState } from "react";
import { Game } from "../../app/models/game";
import { useService } from "../../app/services/services";
import GamesGrid from "./components/gamesGrid";


const Games = () => {
    const [gameslist, setGamesList] = useState<Game[]>([]);

    const {gameService} = useService();
    const {loadGames} = gameService;

    useEffect(() => {
        loadGames().then(games =>{
            if(games)
                setGamesList(games);
        });
    }, [loadGames]); 


    return (
        <Fragment>
            <h1>Games</h1>
            <GamesGrid Games={gameslist}></GamesGrid>
        </Fragment>
    );
};

export default Games;