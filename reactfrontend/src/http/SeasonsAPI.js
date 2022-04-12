import {$host} from "./index";

export const fetchSeasons = async () => {
    const {data} = await $host.get('api/seasons')
    return data
}