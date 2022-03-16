import { makeAutoObservable } from "mobx";
import { MANUFACTURERS_MOCK, RACERS_MOCK, SEASONS_MOCK, TRACKS_MOCK } from "../utils/MockData";

export default class MockStore {
    constructor() {
        this._seasons = SEASONS_MOCK
        this._manufacturers = MANUFACTURERS_MOCK
        this._racers = RACERS_MOCK
        this._tracks = TRACKS_MOCK
        makeAutoObservable(this)
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