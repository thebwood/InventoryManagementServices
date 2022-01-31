import { Container, Paper, TextField, Button, Select, Alert } from '@mui/material';
import { setgid } from 'process';
import React, { Fragment, useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { Game, GameFormValues } from '../../../app/models/game';
import { GameRatings } from '../../../app/models/gameRatings';
import { useService } from '../../../app/services/services';


const GameDetail: React.FC = () => {
    const navigate = useNavigate();
    const { id } = useParams();
    const { gameService } = useService();
    const { loadGame, saveGame, loadGameRatings } = gameService;

    const [game, setGame] = useState<Game>(new Game());
    const [gameRatings, setGameRatings] = useState<GameRatings[]>([]);
    const [errorMessages, setErrorMessages] = useState<string[]>([]);
    const { title, description, gameRatingId } = game;

    useEffect(() => {
        if (id) {
            loadGame(id).then(gameDetail => {
                if (gameDetail)
                    setGame(gameDetail);
            });
        }
        loadGameRatings().then(gameRatingsDetails => {
            if (gameRatingsDetails)
                setGameRatings(gameRatingsDetails);
        })
    }, [loadGame]);


    const handleSave = () => {
        setErrorMessages([]);
        saveGame(game).then(errors =>{
          if(errors && errors.length > 0){
              setErrorMessages(errors);
          }
          else{
            navigate("/games");
          }
        })

    }

    const handleCancel = () => {
        navigate("/games");
    }

    return (
        <Container maxWidth="md">
            {errorMessages.map(error => (
                <Alert severity="error">{error}</Alert>
            ))}
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
                        <div className="col-6">
                            <Select
                                id="GameRating"
                                label="Game Rating"
                                value={gameRatingId}
                                onChange={(e) => setGame({ ...game, gameRatingId: e.target.value ?? undefined })}>
                                <option value={undefined} />
                                {gameRatings.map(rating => (
                                    <option key={rating.id} value={rating.id}>
                                        {rating.rating}
                                    </option>
                                ))}
                            </Select>
                        </div>
                    </div>
                    <div className="row mb-2">
                        <div className="col-12 float-right">
                            <Button variant="contained" onClick={() => handleSave()}>Save</Button>
                            <Button variant="contained" color="error" onClick={() => handleCancel()}>Cancel</Button>
                        </div>
                    </div>
                </div>
            }

        </Container>



    );
};


export default GameDetail;