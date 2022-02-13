export interface IGameSearchFormModel {
    title?: string;
    description?: string;
    releaseYear?: string;
    gameRatingsId?: string;
    gameTypeIds?: [];
}

export class GameSearchFormModel  implements IGameSearchFormModel{
}
