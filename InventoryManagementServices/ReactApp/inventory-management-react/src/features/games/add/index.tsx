import { Paper } from '@mui/material';
import React, {Fragment, useEffect, useState} from 'react';
import { useParams } from 'react-router-dom';
import { Game } from '../../../app/models/game';
import { useService } from '../../../app/services/services';
import GameDetail from '../components/gameDetail';




const AddGame: React.FC =()=> {
    const [game, setGame] = useState<Game>(new Game);
    const {gameService} = useService();


    return (
        <Fragment>
            <h1>New Game</h1>
            <Paper>
                <GameDetail Game={game}></GameDetail>
            </Paper>

        </Fragment>
    );
}


export default AddGame;