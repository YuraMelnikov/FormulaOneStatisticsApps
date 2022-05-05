import {$host} from "./index";

const config = {
    headers: { 'Content-Type': 'application/json'}
};

function formToJSON(elem) {
    let output = {};
    elem.forEach(
      (value, key) => {
        if (Object.prototype.hasOwnProperty.call(output, key)) {
          let current = output[key];
          if (!Array.isArray(current)) {
            current = output[key] = [current];
          }
          current.push(value); 
        } else {
          output[key] = value;
        }
      }
    );
    return JSON.stringify(output);
}

//#region SEASON
export const fetchSeasons = async () => {
    const {data} = await $host.get('api/seasons')
    console.log(data)
    return data
}

export const createSeason = async (season) => {
    const {data} = await $host.post('api/adminSeason/', formToJSON(season), config)
    console.log(data)
    return data
}

export const updateSeason = async (id, season) => {
    console.log(id)
    const {data} = await $host.put('api/adminSeason/' + id, formToJSON(season), config)
    console.log(data)
    return data
}

export const fetchSeasonCalendar = async (id) => {
    const {data} = await $host.get('api/season/calendar/' + id)
    console.log(data)
    return data
}

export const fetchSeasonPercipient = async (id) => {
    const {data} = await $host.get('api/season/percipient/' + id)
    console.log(data)
    return data
}

export const fetchSeasonRacersResult = async (id) => {
    const {data} = await $host.get('api/season/championshipracers/' + id)
    console.log(data)
    return data
}

export const fetchSeasonConstResult = async (id) => {
    const {data} = await $host.get('api/season/championshipteams/' + id)
    console.log(data)
    return data
}
//#endregion

//#region IMAGE
export const fetchImages = async () => {
    const {data} = await $host.get('api/adminImages/')
    console.log(data)
    return data
}

export const fetchImagesBySeason = async (id) => {
    const {data} = await $host.get('api/adminImages/season/' + id)
    console.log(data)
    return data
}

export const fetchImagesByConstructor = async (id) => {
    const {data} = await $host.get('api/adminImages/constructor/' + id)
    console.log(data)
    return data
}

export const deleteImage = async (id) => {
    console.log('APi')
    const {data} = await $host.delete('api/adminImages/' + id)
    console.log(data)
    return data
}
//#endregion

//#region TRACK
export const fetchTracks = async () => {
    const {data} = await $host.get('api/tracks')
    console.log(data)
    return data
}

export const fetchTrackConfigurations = async (id) => {
    const {data} = await $host.get('api/track/configurations/' + id)
    console.log(data)
    return data
}

export const fetchTrackImages = async (id) => {
    const {data} = await $host.get('api/track/images/' + id)
    console.log(data)
    return data
}

export const fetchTrackGrandPrix = async (id) => {
    const {data} = await $host.get('api/track/grandPrix/' + id)
    console.log(data)
    return data
}
//#endregion

//#region RACER
export const fetchRacers = async () => {
    const {data} = await $host.get('api/racers')
    console.log(data)
    return data
}

export const fetchRacerImages = async (id) => {
    const {data} = await $host.get('api/racer/images/' + id)
    console.log(data)
    return data
}

export const fetchRacerInfo = async (id) => {
    const {data} = await $host.get('api/racer/info/' + id)
    console.log(data)
    return data
}

export const fetchRacerClassifications = async (id) => {
    const {data} = await $host.get('api/racer/classifications/' + id)
    console.log(data)
    return data
}

export const fetchRacerSeasons = async (id) => {
    const {data} = await $host.get('api/racer/seasons/' + id)
    console.log(data)
    return data
}
//#endregion

//#region MANUFACTURER
export const fetchManufacturers = async () => {
    const {data} = await $host.get('api/manufacturers')
    console.log(data)
    return data
}
//#endregion

//#region GP
export const fetchGpClassification = async (id) => {
    const {data} = await $host.get('api/grandprix/classification/' + id)
    console.log(data)
    return data
}

export const fetchGpQualification = async (id) => {
    const {data} = await $host.get('api/grandprix/qualification/' + id)
    console.log(data)
    return data
}

export const fetchGpParticipant = async (id) => {
    const {data} = await $host.get('api/grandprix/participants/' + id)
    console.log(data)
    return data
}

export const fetchGpImages = async (id) => {
    const {data} = await $host.get('api/grandprix/images/' + id)
    console.log(data)
    return data
}

export const fetchGpInfo = async (id) => {
    const {data} = await $host.get('api/grandprix/info/' + id)
    console.log(data)
    return data
}

export const fetchGpChampRacers = async (id) => {
    const {data} = await $host.get('api/grandprix/champracers/' + id)
    console.log(data)
    return data
}

export const fetchGpChampConstructors = async (id) => {
    const {data} = await $host.get('api/grandprix/champconstructors/' + id)
    console.log(data)
    return data
}
//#endregion

//#region CONSTRUCTOR
export const fetchConstructors = async () => {
    const {data} = await $host.get('api/constructors')
    console.log(data)
    return data
}

export const fetchAdminConstructors = async () => {
    const {data} = await $host.get('api/adminConstructors')
    console.log(data)
    return data
}

export const fetchConstructorImages = async (id) => {
    const {data} = await $host.get('api/constructor/images/' + id)
    console.log(data)
    return data
}

export const fetchConstructorInfo = async (id) => {
    const {data} = await $host.get('api/constructor/info/' + id)
    console.log(data)
    return data
}

export const fetchConstructorClassifications = async (id) => {
    const {data} = await $host.get('api/constructor/classifications/' + id)
    console.log(data)
    return data
}

export const fetchConstructorSeasons = async (id) => {
    const {data} = await $host.get('api/constructor/seasons/' + id)
    console.log(data)
    return data
}

export const createConstructor = async (constructor) => {
    const {data} = await $host.post('api/adminConstructors/', formToJSON(constructor), config)
    console.log(data)
    return data
}

export const updateConstructor = async (id, constructor) => {
    console.log(id)
    const {data} = await $host.put('api/adminConstructors/' + id, formToJSON(constructor), config)
    console.log(data)
    return data
}
//#endregion

//#region CHASSIS
export const fetchChassisImages = async (id) => {
    const {data} = await $host.get('api/chassis/images/' + id)
    console.log(data)
    return data
}

export const fetchChassisInfo = async (id) => {
    const {data} = await $host.get('api/chassis/info/' + id)
    console.log(data)
    return data
}

export const fetchChassisClassifications = async (id) => {
    const {data} = await $host.get('api/chassis/classifications/' + id)
    console.log(data)
    return data
}

export const fetchChassisSeasons = async (id) => {
    const {data} = await $host.get('api/chassis/seasons/' + id)
    console.log(data)
    return data
}
//#endregion

//#region COUNTRY
export const fetchCountries = async () => {
    const {data} = await $host.get('api/adminCountry/')
    console.log(data)
    return data
}
//#endregion