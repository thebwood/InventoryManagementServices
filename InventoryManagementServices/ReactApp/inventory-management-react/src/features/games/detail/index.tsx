import { Container, Paper, TextField, Button } from '@mui/material';
import { setgid } from 'process';
import React, { Fragment, useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { Game, GameFormValues } from '../../../app/models/game';
import { useService } from '../../../app/services/services';


const GameDetail: React.FC = () => {
    const navigate = useNavigate();
    const { id } = useParams();
    const { gameService } = useService();
    const { loadGame, saveGame } = gameService;

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


    const handleSave = () =>{
        let gameForm = new GameFormValues();
        if(id)
            gameForm.id = id;
        gameForm.title = game.title ?? "";
        gameForm.description = gameForm.description;

        saveGame(gameForm);

    }

    const handleCancel = () =>{
        navigate("/games");
    }

    return (
        <Container maxWidth="md">
            {id && <h3>Game: {id}</h3>}
            {!id && <h3>Add Game</h3>}
                {
                    game &&
                    <div className="container">
                        <div className="row mb-2">
                            <div className="col-6">
                                <TextField
                                    id="Title"
                                    label="Title"
                                    fullWidth
                                    value={title || ''}
                                    inputProps={{
                                        maxLength: 50
                                    }}
                                    onChange={(e) => setGame({ ...game, title: e.target.value })}
                                ></TextField>

                            </div>


                        </div>
                        <div className="row mb-2">
                            <div className="col-12">
                                <TextField
                                    id="Description"
                                    label="Description"
                                    fullWidth
                                    value={description || ''}
                                    inputProps={{
                                        maxLength: 200
                                    }}
                                    onChange={(e) => setGame({ ...game, description: e.target.value })}
                                ></TextField>
                            </div>
                        </div>
                        <div className="row mb-2">
                            <div className="col-12 float-right">
                                <Button variant="contained" onClick={() => handleSave()}>Save</Button>
                                <Button variant="contained" onClick={() => handleCancel()}>Cancel</Button>
                            </div>
                        </div>
                    </div>
                }

        </Container>



    );
};


export default GameDetail;