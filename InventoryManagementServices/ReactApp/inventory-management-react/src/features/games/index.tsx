import React, { Fragment, useEffect, useState } from "react";
import { Game } from "../../app/models/game";
import { useService } from "../../app/services/services";
import GamesGrid from "./components/gamesGrid";


const Games: React.FC = () => {
    const [games, setGames] = useState<Game[]>([]);

    const {gameService} = useService();
    const {loadGames} = gameService;

    useEffect(() => {
        loadGames().then(gamesList =>{
            if(gamesList)
                setGames(gamesList);
        });
    }, [loadGames]); 


    return (
        <Fragment>
            <h1>Games</h1>
            <GamesGrid Games={games}></GamesGrid>
        </Fragment>
    );
};

export default Games;