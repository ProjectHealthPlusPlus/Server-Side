﻿namespace HealthPlusPlus_AW.Profile.Domain.Repositories
{
    public abstract class User
    {
        public int Id { get; set; } 
        public string Dni { get; set; } 
        public string Name { get; set; } 
        public string Lastname { get; set; }
        public int Age { get; set; }
    }
}