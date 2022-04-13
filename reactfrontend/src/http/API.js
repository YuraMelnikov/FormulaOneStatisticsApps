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