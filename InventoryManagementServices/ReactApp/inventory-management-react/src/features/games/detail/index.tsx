import { Container, TextField, Button, Select, Alert, FormControl, InputLabel, MenuItem } from '@mui/material';
import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { Game } from '../../../app/models/games/game';
import { GameRatings } from '../../../app/models/games/gameRatings';
import { useService } from '../../../app/services/services';


const GameDetail: React.FC = () => {
    const navigate = useNavigate();
    const { id } = useParams();
    const { gameService } = useService();
    const { loadGame, saveGame, loadGameRatings } = gameService;

    const [game, setGame] = useState<Game>(new Game());
    const [gameRatings, setGameRatings] = useState<GameRatings[]>([]);
    const [errorMessages, setErrorMessages] = useState<string[]>([]);
    const { title, description, gameRatingsId } = game;

    useEffect(() => {
        loadGameRatings().then(gameRatingsDetails => {
            if (gameRatingsDetails)
                setGameRatings(gameRatingsDetails);
        });
        
        if (id) {
            loadGame(id).then(gameDetail => {
                if (gameDetail)
                    setGame(gameDetail);
            });
        }

    }, [loadGame]);


    const handleSave = () => {
        setErrorMessages([]);
        saveGame(game).then(errors => {
            if (errors && errors.length > 0) {
                setErrorMessages(errors);
            }
            else {
                navigate("/games");
            }
        })

    }

    const handleCancel = () => {
        navigate("/games");
    }

    return (
        <Container maxWidth="md">

            {(errorMessages && errorMessages.length > 0) && errorMessages.map(error => (
                <Alert severity="error">{error}</Alert>
            ))}
            {id ? <h4>Game: {id}</h4> : <h4>Add Game</h4>}
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
                        <div className="col-6">
                            <FormControl fullWidth>
                            <InputLabel>Game Rating</InputLabel>
                            <Select
                                id="GameRating"
                        
                                value={gameRatingsId || ""}
                                onChange={(e) => setGame({ ...game, gameRatingsId: e.target.value })}>
                                <MenuItem value="">Clear Selection</MenuItem>
                                {gameRatings.map(rating => (
                                    <MenuItem key={rating.id} value={rating.id}>
                                        {rating.rating}
                                    </MenuItem>
                                ))}
                            </Select>
                        </FormControl>

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
                        <div className="col-12">
                            
                        </div>
                    </div>
                    <div className="row mb-2">
                        <div className="col-12 text-right">
                            <Button className="mr-1" variant="contained" onClick={() => handleSave()}>Save</Button>
                            <Button variant="contained" color="error" onClick={() => handleCancel()}>Cancel</Button>
                        </div>
                    </div>
                </div>
            }

        </Container>



    );
};


export default GameDetail;