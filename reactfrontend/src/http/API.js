import {$host} from "./index";

export const fetchSeasons = async () => {
    const {data} = await $host.get('api/seasons')
    console.log(data);
    return data
}

export const fetchTracks = async () => {
    const {data} = await $host.get('api/tracks')
    console.log(data);
    return data
}

export const fetchRacers = async () => {
    const {data} = await $host.get('api/racers')
    console.log(data);
    return data
}

export const fetchManufacturers = async () => {
    const {data} = await $host.get('api/manufacturers')
    console.log(data);
    return data
}

export const fetchSeasonCalendar = async (id) => {
    const {data} = await $host.get('api/season/calendar/' + id)
    console.log(data);
    return data
}

export const fetchSeasonPercipient = async (id) => {
    const {data} = await $host.get('api/season/percipient/' + id)
    console.log(data);
    return data
}

export const fetchSeasonRacersResult = async (id) => {
    const {data} = await $host.get('api/season/championshipracers/' + id)
    console.log(data);
    return data
}

export const fetchSeasonConstResult = async (id) => {
    const {data} = await $host.get('api/season/championshipteams/' + id)
    console.log(data);
    return data
}

export const fetchGpClassification = async (id) => {
    const {data} = await $host.get('api/grandprix/classification/' + id)
    console.log(data);
    return data
}

export const fetchGpQualification = async (id) => {
    const {data} = await $host.get('api/grandprix/qualification/' + id)
    console.log(data);
    return data
}

export const fetchGpParticipant = async (id) => {
    const {data} = await $host.get('api/grandprix/participants/' + id)
    console.log(data);
    return data
}

export const fetchGpImages = async (id) => {
    const {data} = await $host.get('api/grandprix/images/' + id)
    console.log(data);
    return data
}

export const fetchGpInfo = async (id) => {
    const {data} = await $host.get('api/grandprix/info/' + id)
    console.log(data);
    return data
}

export const fetchGpChampRacers = async (id) => {
    const {data} = await $host.get('api/grandprix/champracers/' + id)
    console.log(data);
    return data
}

export const fetchGpChampConstructors = async (id) => {
    const {data} = await $host.get('api/grandprix/champconstructors/' + id)
    console.log(data);
    return data
}