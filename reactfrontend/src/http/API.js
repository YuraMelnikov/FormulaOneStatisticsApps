import {$host} from "./index";

const config = {
    headers: { 
        'Content-Type': 'application/json',
    }
};

function form2json(data) {
    let method = function (object,pair) {
        let keys = pair[0].replace(/\]/g,'').split('[');
        let key = keys[0];
        let value = pair[1];
        if (keys.length > 1) {
            let i,x,segment;
            let last = value;
            let type = isNaN(keys[1]) ? {} : [];
            value = segment = object[key] || type;
            for (i = 1; i < keys.length; i++) {
                x = keys[i];
                if (i === keys.length-1) {
                    if (Array.isArray(segment)) {
                        segment.push(last);
                    } else {
                        segment[x] = last;
                    }
                } else if (segment[x] === undefined) {
                    segment[x] = isNaN(keys[i+1]) ? {} : [];
                }
                segment = segment[x];
            }
        }
        object[key] = value;
        return object;
    }
    let object = Array.from(data).reduce(method,{});
    return JSON.stringify(object);
}

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

export const saveImage = async (file) => {
    try {
        const {data} = await $host.post('api/AdminImages/save/', file)
        return(data)
    }
    catch (ex){
        console.log(ex)
    }
}

export const createImage = async (image) => {
    const newData = JSON.parse(form2json(image))
    const {data} = await $host.post('api/AdminImages/', newData, config)
    return data
}

export const deleteImage = async (id) => {
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

export const createManufacturer = async (manufacturer) => {
    const {data} = await $host.post('api/adminManufacturer/', formToJSON(manufacturer), config)
    return data
}
//#endregion

//#region GP
export const fetchGrandPrix = async () => {
    const {data} = await $host.get('api/adminGrandPrix/')
    console.log(data)
    return data
}

export const fetchGpAdminClassification = async (id) => {
    const {data} = await $host.get('api/adminGrandPrix/classification/' + id)
    console.log(data)
    return data
}

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

export const fetchGpFastLap = async (id) => {
    const {data} = await $host.get('api/grandprix/fastLap/' + id)
    console.log(data)
    return data
}

export const fetchGpLeaderLap = async (id) => {
    const {data} = await $host.get('api/grandprix/leaderLap/' + id)
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

export const updateGrandPrix = async (id, grandPrix) => {
    const {data} = await $host.put('api/adminGrandPrix/' + id, formToJSON(grandPrix), config)
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

export const createChassis = async (chassis) => {
    const {data} = await $host.post('api/adminChassis/', formToJSON(chassis), config)
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

//#region QUALIFICATION
export const fetchQualification = async (id) => {
    const {data} = await $host.get('api/adminQualification/' + id)
    return data
}

export const updateQualification = async (qualification) => {
    console.log(formToJSON(qualification))
    const {data} = await $host.put('api/adminQualification/', formToJSON(qualification), config)
    return data
}

export const deleteQualification = async (qualification) => {
    const {data} = await $host.put('api/adminQualification/', formToJSON(qualification), config)
    return data
}
//#endregion

//#region GRANDPRIXRESULT
export const fetchGrandPrixResult = async (id) => {
    const {data} = await $host.get('api/adminGrandPrixResult/' + id)
    console.log(data)
    return data
}

export const updateGrandPrixResult = async (result) => {
    const {data} = await $host.put('api/adminGrandPrixResult/', formToJSON(result), config)
    console.log(data)
    return data
}
//#endregion

//#region ENGINE
export const createEngine = async (engine) => {
    const {data} = await $host.post('api/adminEngine/', formToJSON(engine), config)
    return data
}
//#endregion

//#region TEAM
export const createTeam = async (team) => {
    const {data} = await $host.post('api/adminTeam/', formToJSON(team), config)
    return data
}
//#endregion

//#region TEAMNAME
export const createTeamName = async (teamName) => {
    const {data} = await $host.post('api/adminTeamName/', formToJSON(teamName), config)
    return data
}
//#endregion