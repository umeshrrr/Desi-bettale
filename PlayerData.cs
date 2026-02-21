using System.Collections.Generic;

namespace DesiShadow.Core
{
    [System.Serializable]
    public class PlayerData
    {
        // Currencies
        public int Coins;
        public int Gems;

        // Progression
        public int PlayerLevel;
        public float CurrentXP;
        public float MaxXP;
        
        // Retention
        public int DailyLoginStreak;
        public string LastLoginDate;

        // Inventory (Store Item IDs as strings)
        public List<string> UnlockedWeapons;
        public List<string> UnlockedSkins;

        // Constructor sets default values for a new player
        public PlayerData()
        {
            Coins = 0;
            Gems = 0;
            PlayerLevel = 1;
            CurrentXP = 0;
            MaxXP = 100;
            DailyLoginStreak = 0;
            UnlockedWeapons = new List<string>() { "Pistol_Basic" }; // Default weapon
            UnlockedSkins = new List<string>();
        }
    }
}
