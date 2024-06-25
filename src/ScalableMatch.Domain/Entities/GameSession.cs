﻿namespace ScalableMatch.Domain.Entities
{
    public class GameSession
    {
        public List<Player> Players { get; set; } = [];
        public int MaxPlayers { get; set; }
        public string Status { get; set; }
    }
}
