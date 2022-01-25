import axios, { AxiosError, AxiosResponse } from 'axios';
import { useNavigate } from 'react-router-dom';
import { Game, GameFormValues } from '../models/game';
import { GameSearch } from '../models/gameSearch';
import { GameSearchResults } from '../models/gameSearchResults';
import { Movie, MovieFormValues } from '../models/movie';
import { PaginatedResult } from '../models/pagination';


//const navigate = useNavigate();
const sleep = (delay: number) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay)
    })
}

// need to implement an API Gateway
axios.defaults.baseURL = process.env.GAME_API_URL


// axios.interceptors.response.use(async response => {
//     if (process.env.NODE_ENV === 'development') await sleep(1000);
//     const pagination = response.headers['pagination'];
//     if (pagination) {
//         response.data = new PaginatedResult(response.data, JSON.parse(pagination));
//         return response as AxiosResponse<PaginatedResult<any>>
//     }
//     return response;
// }, (error: AxiosError) => {
//     const { data, status, config, headers } = error.response!;
//     switch (status) {
//         case 400:
//             if (config.method === 'get' && data.errors.hasOwnProperty('id')) {
//                 navigate('/not-found');
//             }
//             if (data.errors) {
//                 const modalStateErrors = [];
//                 for (const key in data.errors) {
//                     if (data.errors[key]) {
//                         modalStateErrors.push(data.errors[key])
//                     }
//                 }
//                 throw modalStateErrors.flat();
//             }
//             break;
//         case 404:
//             navigate('/not-found');
//             break;
//         case 500:
//             navigate('/server-error');
//             break;
//     }
//     return Promise.reject(error);
// })

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
}

// const Games = {
//     search: (params: GameSearch)=> axios.post<PaginatedResult<GameSearchResults[]>>('/games', params)
//             .then(responseBody),
//     list: () => axios.get<Game[]>('/games')
//         .then(responseBody),
//     details: (id: string) => requests.get<Game>(`/games/${id}`),
//     create: (activity: GameFormValues) => requests.post<void>('/games', activity),
//     update: (activity: GameFormValues) => requests.put<void>(`/games/${activity.id}`, activity),

// }


const Games = {
    search: (params: GameSearch)=> {
        axios.post<GameSearchResults[]>('http://localhost:5109/api/games', params)
            .then(responseBody);
    },

    list: () => {
        return axios.get<Game[]>('http://localhost:5109/api/games')
            .then(responseBody)
    },
    details: (id: string) => {
        return requests.get<Game>('http://localhost:5109/api/games/${id}');
    },
    save: (game: GameFormValues) => {
        return requests.post<void>('http://localhost:5109/api/games', game);
    }
}


const Movies = {
    list: () => {
        return axios.get<Movie[]>('http://localhost:5091/api/movies')
            .then(responseBody)
    },
    details: (id: string) => {
        return requests.get<Movie>('http://localhost:5091/apimovies/${id}');
    },
    save: (movie: MovieFormValues) => {
        return requests.post<void>('http://localhost:5091/api/movies', movie);
    }

}

const agent = {
    Games,
    Movies
}

export default agent;