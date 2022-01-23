﻿namespace Game.API.Models
{
    public class GamesModel
    {
        public Guid? Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid? GameRatingsId { get; set; }
    }
}
