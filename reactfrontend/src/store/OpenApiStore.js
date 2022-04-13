import { makeAutoObservable } from "mobx";

export default class OpenApiStore {
    constructor() {
        this._seasons = []
        this._tracks = []
        this._racers = []
        this._manufacturers = []
        makeAutoObservable(this)
    }

    setManufacturers(manufacturers) {
        this._manufacturers = manufacturers
    }
    get manufacturers() {
        return this._manufacturers
    }

    setSeasons(seasons) {
        this._seasons = seasons
    }
    get seasons() {
        return this._seasons
    }

    setTracks(tracks) {
        this._tracks = tracks
    }
    get tracks() {
        return this._tracks
    }

    setRacers(racers) {
        this._racers = racers
    }
    get racers() {
        return this._racers
    }
}