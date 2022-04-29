import { 
    ABOUTAPI_ROUTE, 
    ABOUTUS_ROUTE, 
    GRANDPRIX_ROUTE, 
    MANUFACTURERS_ROUTE, 
    MANUFACTURER_ROUTE, 
    RACERS_ROUTE, 
    RACER_ROUTE, 
    SEASONS_ROUTE, 
    SEASON_ROUTE, 
    STATISTICS_ROUTE, 
    TRACKS_ROUTE, 
    TRACK_ROUTE, 
    CONSTRUCTOR_ROUTE, 
    CONSTRUCTORS_ROUTE, 
    CHASSIS_ROUTE,
    ADMIN_ROUTE
} from "./utils/Constants";
import AboutAPI from './pages/AboutAPI';
import AboutUs from './pages/AboutUs';
import GrandPrix from './pages/GrandPrix';
import Manufacturer from './pages/Manufacturer';
import Manufacturers from './pages/Manufacturers';
import Racer from './pages/Racer';
import Racers from './pages/Racers';
import Season from './pages/Season';
import Seasons from './pages/Seasons';
import Statistics from './pages/Statistics';
import Track from './pages/Track';
import Tracks from './pages/Tracks';
import Chassis from './pages/Chassis';
import Constructor from './pages/Constructor';
import Constructors from './pages/Constructors';
import Admin from './pages/Admin';

export const publicRoutes = [
    {
        path: ADMIN_ROUTE,
        Component: Admin
    },
    {
        path: CONSTRUCTOR_ROUTE + '/:id',
        Component: Constructor
    },
    {
        path: CONSTRUCTORS_ROUTE,
        Component: Constructors
    },
    {
        path: CHASSIS_ROUTE + '/:id',
        Component: Chassis
    },
    {
        path: ABOUTAPI_ROUTE,
        Component: AboutAPI
    },
    {
        path: ABOUTUS_ROUTE,
        Component: AboutUs
    },
    {
        path: GRANDPRIX_ROUTE + '/:id',
        Component: GrandPrix
    },
    {
        path: MANUFACTURER_ROUTE + '/:id',
        Component: Manufacturer
    },
    {
        path: MANUFACTURERS_ROUTE,
        Component: Manufacturers
    },
    {
        path: RACER_ROUTE + '/:id',
        Component: Racer
    },
    {
        path: RACERS_ROUTE,
        Component: Racers
    },
    {
        path: SEASON_ROUTE + '/:id',
        Component: Season
    },
    {
        path: STATISTICS_ROUTE,
        Component: Statistics
    },
    {
        path: TRACK_ROUTE + '/:id',
        Component: Track
    },
    {
        path: TRACKS_ROUTE,
        Component: Tracks
    },
    {
        path: SEASONS_ROUTE,
        Component: Seasons
    },
]