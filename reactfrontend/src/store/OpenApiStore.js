import { makeAutoObservable } from "mobx";

export default class OpenApiStore {
    constructor() {
        this._seasons = []
        this._tracks = []
        this._racers = []
        this._manufacturers = []
        this._seasonCalendar = []
        this._seasonPercipient = []
        this._seasonRacersResult = []
        this._seasonConstResult = []
        this._gpClassification = []
        this._gpQualification = []
        this._gpParticipant = []

        makeAutoObservable(this)
    }

    setGpParticipant(gpParticipant) {
        this._gpParticipant = gpParticipant
    }
    get gpParticipant() {
        return this._gpParticipant
    }

    setGpQualification(gpQualification) {
        this._gpQualification = gpQualification
    }
    get gpQualification() {
        return this._gpQualification
    }

    setGpClassification(gpClassification) {
        this._gpClassification = gpClassification
    }
    get gpClassification() {
        return this._gpClassification
    }

    setSeasonConstResult(seasonConstResult) {
        this._seasonConstResult = seasonConstResult
    }
    get seasonConstResult() {
        return this._seasonConstResult
    }

    setSeasonRacersResult(seasonRacersResult) {
        this._seasonRacersResult = seasonRacersResult
    }
    get seasonRacersResult() {
        return this._seasonRacersResult
    }

    setSeasonPercipient(seasonPercipient) {
        this._seasonPercipient = seasonPercipient
    }
    get seasonPercipient() {
        return this._seasonPercipient
    }

    setSeasonCalendar(seasonCalendar) {
        this._seasonCalendar = seasonCalendar
    }
    get seasonCalendar() {
        return this._seasonCalendar
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