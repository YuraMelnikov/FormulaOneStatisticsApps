import { makeAutoObservable } from "mobx";

export default class OpenApiStore {
    constructor() {
        this._seasons = []
        this._seasonCalendar = []
        this._seasonPercipient = []
        this._seasonRacersResult = []
        this._seasonConstResult = []

        this._tracks = []
        this._trackConfigurations = []
        this._trackImages = []
        this._trackGrandPrix = []

        this._racers = []
        this._racerImages = []
        this._racerInfo = []
        this._racerClassifications = []
        this._racerSeasons = []

        this._manufacturers = []

        this._gpClassification = []
        this._gpQualification = []
        this._gpParticipant = []
        this._gpImages = []
        this._gpInfo = []
        this._gpFastLap = []
        this._gpChampRacers = []
        this._gpChampConstructors = []
        this._grandPrix = []
        this._gpLeaderLap = []

        this._constructors = []
        this._constructorImages = []
        this._constructorInfo = []
        this._constructorClassifications = []
        this._constructorSeasons = []

        this._chassisImages = []
        this._chassisInfo = []
        this._chassisClassifications = []
        this._chassisSeasons = []


        this._images = []

        this._country = []

        this._selectedImage = {}
        this._selectedLogo = {}
        this._selectedCountry = {}
        this._selectItem = {}

        makeAutoObservable(this)
    }

//#region SEASON
setSeasons(seasons) {
    this._seasons = seasons
}
get seasons() {
    return this._seasons
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

//#endregion

//#region TRACK
setTracks(tracks) {
    this._tracks = tracks
}
get tracks() {
    return this._tracks
}

setTrackGrandPrix(trackGrandPrix) {
    this._trackGrandPrix = trackGrandPrix
}
get trackGrandPrix() {
    return this._trackGrandPrix
}

setTrackImages(trackImages) {
    this._trackImages = trackImages
}
get trackImages() {
    return this._trackImages
}

setTrackConfigurations(trackConfigurations) {
    this._trackConfigurations = trackConfigurations
}
get trackConfigurations() {
    return this._trackConfigurations
}
//#endregion

//#region RACER
setRacerImages(racerImages) {
    this._racerImages = racerImages
}
get racerImages() {
    return this._racerImages
}

setRacerInfo(racerInfo) {
    this._racerInfo = racerInfo
}
get racerInfo() {
    return this._racerInfo
}

setRacerClassifications(racerClassifications) {
    this._racerClassifications = racerClassifications
}
get racerClassifications() {
    return this._racerClassifications
}

setRacerSeasons(racerSeasons) {
    this._racerSeasons = racerSeasons
}
get racerSeasons() {
    return this._racerSeasons
}

setRacers(racers) {
    this._racers = racers
}
get racers() {
    return this._racers
}
//#endregion

//#region MANUFACTURER
setManufacturers(manufacturers) {
    this._manufacturers = manufacturers
}
get manufacturers() {
    return this._manufacturers
}
//#endregion

//#region GP
setGrandPrix(grandPrix) {
    this._grandPrix = grandPrix
}
get grandPrix() {
    return this._grandPrix
}

setGpChampConstructors(gpChampConstructors) {
    this._gpChampConstructors = gpChampConstructors
}
get gpChampConstructors() {
    return this._gpChampConstructors
}

setGpChampRacers(gpChampRacers) {
    this._gpChampRacers = gpChampRacers
}
get gpChampRacers() {
    return this._gpChampRacers
}

setGpInfo(gpInfo) {
    this._gpInfo = gpInfo
}
get gpInfo() {
    return this._gpInfo
}

setGpFastLap(gpFastLap) {
    this._gpFastLap = gpFastLap
}
get gpFastLap() {
    return this._gpFastLap
}

setGpImages(gpImages) {
    this._gpImages = gpImages
}
get gpImages() {
    return this._gpImages
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

setGpLeaderLap(gpLeaderLap) {
    this._gpLeaderLap = gpLeaderLap
}
get gpLeaderLap() {
    return this._gpLeaderLap
}
//#endregion

//#region CONSTRUCTOR
setConstructorSeasons(constructorSeasons) {
    this._constructorSeasons = constructorSeasons
}
get constructorSeasons() {
    return this._constructorSeasons
}

setConstructorClassifications(constructorClassifications) {
    this._constructorClassifications = constructorClassifications
}
get constructorClassifications() {
    return this._constructorClassifications
}

setConstructorInfo(constructorInfo) {
    this._constructorInfo = constructorInfo
}
get constructorInfo() {
    return this._constructorInfo
}

setConstructorImages(constructorImages) {
    this._constructorImages = constructorImages
}
get constructorImages() {
    return this._constructorImages
}

setConstructors(constructors) {
    this._constructors = constructors
}
get constructors() {
    return this._constructors
}
//#endregion

//#region CHASSIS
setChassisSeasons(chassisSeasons) {
    this._chassisSeasons = chassisSeasons
}
get chassisSeasons() {
    return this._chassisSeasons
}

setChassisClassifications(chassisClassifications) {
    this._chassisClassifications = chassisClassifications
}
get chassisClassifications() {
    return this._chassisClassifications
}

setChassisInfo(chassisInfo) {
    this._chassisInfo = chassisInfo
}
get chassisInfo() {
    return this._chassisInfo
}

setChassisImages(chassisImages) {
    this._chassisImages = chassisImages
}
get chassisImages() {
    return this._chassisImages
}
//#endregion

//#region IMAGE
setImages(images) {
    this._images = images
}
get images() {
    return this._images
}
//#endregion

//#region COUNTRY
setCountry(country) {
    this._country = country
}
get country() {
    return this._country
}
//#endregion

//#region SELECT
setSelectItem(item) {
    this._selectItem = item
}
get selectItem() {
    return this._selectItem
}

setSelectedCountry(country) {
    this._selectedCountry = country
}
get selectedCountry() {
    return this._selectedCountry
}

setSelectedLogo(image) {
    this._selectedLogo = image
}
get selectedLogo() {
    return this._selectedLogo
}

setSelectedImage(image) {
    this._selectedImage = image
}
get selectedImage() {
    return this._selectedImage
}
//#endregion
}