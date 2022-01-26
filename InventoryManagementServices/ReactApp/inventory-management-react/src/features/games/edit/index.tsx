import { Paper } from '@mui/material';
import React, {Fragment, useEffect, useState} from 'react';
import { useParams } from 'react-router-dom';
import { Game } from '../../../app/models/game';
import { useService } from '../../../app/services/services';
import GameDetail from '../components/gameDetail';




const EditGame: React.FC =()=> {
    const {id} = useParams();
    const [game, setGame] = useState<Game>(new Game);
    const {gameService} = useService();
    const {loadGame} = gameService;

    useEffect(() => {
        if(id)
        {
            loadGame(id).then(gameDetail =>{
                if(gameDetail)
                    setGame(gameDetail);
            });
        }
    }, [loadGame]); 

    return (
        <Fragment>
            <h1>Game: {id}</h1>
            <Paper>
                <GameDetail Game={game}></GameDetail>
            </Paper>

        </Fragment>
    );
}


export default EditGame;