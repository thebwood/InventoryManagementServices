import { FC } from "react";
import { Route, Routes } from "react-router-dom";
import { REACT_ROUTES } from "../constants/constants";
import Dashboard from "../../features/dashboard";
import Games from "../../features/games";
import Movies from "../../features/movies";
import Home from "../../features/home";

import GameDetail from "../../features/games/detail";
import MovieDetail from "../../features/movies/detail";


const AppRoutes: FC = () => {
    return <Routes>
        <Route path={REACT_ROUTES.HOME} element={<Home />} />
        <Route path={REACT_ROUTES.DASHBOARD} element={<Dashboard />} />
        <Route path={REACT_ROUTES.GAMES} element={<Games />} />
        <Route path={REACT_ROUTES.ADDGAME} element={<GameDetail />} />
        <Route path={REACT_ROUTES.EDITGAME} element={<GameDetail />} />
        <Route path={REACT_ROUTES.MOVIES} element={<Movies />} />
        <Route path={REACT_ROUTES.ADDMOVIE} element={<MovieDetail />} />
        <Route path={REACT_ROUTES.EDITMOVIE} element={<MovieDetail />} />
        <Route path="*" element={<Dashboard />} />
    </Routes>;
}
export default AppRoutes;