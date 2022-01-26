import { FC } from "react";
import { Route, Routes } from "react-router-dom";
import { REACT_ROUTES } from "../constants/constants";
import Dashboard from "../../features/dashboard";
import Games from "../../features/games";
import Movies from "../../features/movies";
import Home from "../../features/home";
import AddGame from "../../features/games/add";
import EditGame from "../../features/games/edit";
import AddMovie from "../../features/movies/add";
import EditMovie from "../../features/movies/edit";


const AppRoutes: FC = () => {
    return <Routes>
        <Route path={REACT_ROUTES.HOME} element={<Home />} />
        <Route path={REACT_ROUTES.DASHBOARD} element={<Dashboard />} />
        <Route path={REACT_ROUTES.GAMES} element={<Games />} />
        <Route path={REACT_ROUTES.ADDGAME} element={<AddGame />} />
        <Route path={REACT_ROUTES.EDITGAME} element={<EditGame />} />
        <Route path={REACT_ROUTES.MOVIES} element={<Movies />} />
        <Route path={REACT_ROUTES.ADDMOVIE} element={<AddMovie />} />
        <Route path={REACT_ROUTES.EDITMOVIE} element={<EditMovie />} />
        <Route path="*" element={<Dashboard />} />
    </Routes>;
}
export default AppRoutes;