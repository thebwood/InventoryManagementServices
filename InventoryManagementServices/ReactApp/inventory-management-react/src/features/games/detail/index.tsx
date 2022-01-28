import { Container, Paper, TextField } from '@mui/material';
import { setgid } from 'process';
import React, { Fragment, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Game } from '../../../app/models/game';
import { useService } from '../../../app/services/services';


const GameDetail: React.FC = () => {
    const { id } = useParams();
    const { gameService } = useService();
    const { loadGame } = gameService;

    const [game, setGame] = useState<Game>(new Game());
    const { title, description } = game;

    useEffect(() => {
        if (id) {
            loadGame(id).then(gameDetail => {
                if (gameDetail)
                    setGame(gameDetail);
            });
        }
    }, [loadGame]);

    return (
        <Container maxWidth="md">
            {id && <h3>Game: {id}</h3>}
            {!id && <h3>Add Game</h3>}
                {
                    game &&
                    <div className="container">
                        <div className="row">
                            <div className="col-6">
                                <TextField
                                    id="Title"
                                    label="Title"
                                    value={title || ''}
                                    inputProps={{
                                        maxLength: 50
                                    }}
                                    onChange={(e) => setGame({ ...game, title: e.target.value })}
                                ></TextField>

                            </div>


                        </div>
                        <div className="row">
                            <div className="col-12">
                                <TextField
                                    id="Description"
                                    label="Description"
                                    value={description || ''}
                                    inputProps={{
                                        maxLength: 200
                                    }}
                                    onChange={(e) => setGame({ ...game, description: e.target.value })}
                                ></TextField>
                            </div>
                        </div>
                    </div>
                }

        </Container>



    );
};


export default GameDetail;