import { makeAutoObservable } from "mobx";
import { MANUFACTURERS_MOCK, RACERS_MOCK, SEASONS_MOCK, TRACKS_MOCK, SEASONCALENDAR_MOCK,
    SEASONPARCIPIENT_MOCK, SEASONCHAMPIONSIPRACERS_MOCK, SEASONCHAMPIONSHIPTEAMS_MOCK
 } from "../utils/MockData";

export default class MockStore {
    constructor() {
        this._seasons = SEASONS_MOCK
        this._manufacturers = MANUFACTURERS_MOCK
        this._racers = RACERS_MOCK
        this._tracks = TRACKS_MOCK
        this._seasonCalendar = SEASONCALENDAR_MOCK
        this._seasonPercipient = SEASONPARCIPIENT_MOCK
        this._seasonChampRacers = SEASONCHAMPIONSIPRACERS_MOCK
        this._seasonChampTeams = SEASONCHAMPIONSHIPTEAMS_MOCK
        makeAutoObservable(this)
    }

    setSeasonChampTeams(seasonChampTeams) {
        this._seasonChampTeams = seasonChampTeams
    }

    get seasonChampTeams () {
        return this._seasonChampTeams
    }

    setSeasonChampRacers(seasonChampRacers) {
        this._seasonChampRacers = seasonChampRacers
    }

    get seasonChampRacers() {
        return this._seasonChampRacers
    }

    setSeasonPercipient(seasonPercipient){
        this._seasonPercipient = seasonPercipient
    }

    get seasonPercipient(){
        return this._seasonPercipient
    }

    setSeasonCalendar(seasonCalendar) {
        this._seasonCalendar = seasonCalendar
    }

    get seasonCalendar() {
        return this._seasonCalendar
    }

    setSeasons(seasons) {
        this._seasons = seasons
    }

    get seasons() {
        return this._seasons
    }

    setManufacturers(manufacturers) {
        this._manufacturers = manufacturers
    }

    get manufacturers() {
        return this._manufacturers
    }

    setRacers(racers) {
        this._racers = racers
    }

    get racers() {
        return this._racers
    }

    setTracks(tracks) {
        this._tracks = tracks
    }

    get tracks() {
        return this._tracks
    }
}