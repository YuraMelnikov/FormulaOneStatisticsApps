import { makeAutoObservable } from "mobx";
import { SEASONCHAMPIONSIPRACERS_MOCK, SEASONCHAMPIONSHIPTEAMS_MOCK,
    GPPARTICIPANT_MOCK, GPQUALIFICATION_MOCK, GPCLASSIFICATION_MOCK, RACERRESULT_MOCK

 } from "../utils/MockData";

export default class MockStore {
    constructor() {
        this._seasonChampRacers = SEASONCHAMPIONSIPRACERS_MOCK
        this._seasonChampTeams = SEASONCHAMPIONSHIPTEAMS_MOCK
        this._gpParticipant = GPPARTICIPANT_MOCK
        this._gpQualification = GPQUALIFICATION_MOCK
        this._gpClassification = GPCLASSIFICATION_MOCK
        this._racerResult = RACERRESULT_MOCK
        makeAutoObservable(this)
    }

    setRacerResult(racerResult) {
        this._racerResult = racerResult
    }

    get racerResult () {
        return this._racerResult
    }

    setGpClassification(gpClassification) {
        this._gpClassification = gpClassification
    }

    get gpClassification () {
        return this._gpClassification
    }

    setGpQualification(gpQualification) {
        this._gpQualification = gpQualification
    }

    get gpQualification () {
        return this._gpQualification
    }

    setGpParticipant(gpParticipant) {
        this._gpParticipant = gpParticipant
    }

    get gpParticipant () {
        return this._gpParticipant
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
}