import React from "react";
import { Routes, Route } from "react-router-dom";
import { CONSTRUCTOR_ROUTE, CONSTRUCTORS_ROUTE, GRANDPRIX_ROUTE, INDEX_ROUTE,
    MANUFACTURER_ROUTE, MANUFACTURERS_ROUTE, RACER_ROUTE, RACERS_ROUTE, SEASON_ROUTE,
    SEASONS_ROUTE, TRACK_ROUTE, TRACKS_ROUTE } from "../utils/Links";
import Constructor from '../pages/Constructor';
import Constructors from '../pages/Constructors';
import GrandPrix from '../pages/GrandPrix';
import Index from '../pages/Index';
import Manufacturer from '../pages/Manufacturer';
import Manufacturers from '../pages/Manufacturers';
import Racer from '../pages/Racer';
import Racers from '../pages/Racers';
import Season from '../pages/Season';
import Seasons from '../pages/Seasons';
import Track from '../pages/Track';
import Tracks from '../pages/Tracks';

const AppRouter = () => {
    return (
        <Routes>
            <Route path={CONSTRUCTOR_ROUTE} element={<Constructor />} />
            <Route path={CONSTRUCTORS_ROUTE} element={<Constructors />} />
            <Route path={GRANDPRIX_ROUTE} element={<GrandPrix />} />
            <Route path={INDEX_ROUTE} element={<Index />} />
            <Route path={MANUFACTURER_ROUTE} element={<Manufacturer />} />
            <Route path={MANUFACTURERS_ROUTE} element={<Manufacturers />} />
            <Route path={RACER_ROUTE} element={<Racer />} />
            <Route path={RACERS_ROUTE} element={<Racers />} />
            <Route path={SEASON_ROUTE} element={<Season />} />
            <Route path={SEASONS_ROUTE} element={<Seasons />} />
            <Route path={TRACK_ROUTE} element={<Track />} />
            <Route path={TRACKS_ROUTE} element={<Tracks />} />
        </Routes>
    );
}

export default AppRouter;