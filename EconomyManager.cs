using UnityEngine;
using System;

namespace DesiShadow.Core
{
    public class EconomyManager : Singleton<EconomyManager>
    {
        // Events to update UI automatically
        public static event Action<int> OnCoinsChanged;
        public static event Action<int> OnGemsChanged;

        public void AddCoins(int amount)
        {
            SaveManager.Instance.CurrentSaveData.Coins += amount;
            SaveManager.Instance.SaveGame();
            
            // Notify UI
            OnCoinsChanged?.Invoke(SaveManager.Instance.CurrentSaveData.Coins);
        }

        public void AddGems(int amount)
        {
            SaveManager.Instance.CurrentSaveData.Gems += amount;
            SaveManager.Instance.SaveGame();
            OnGemsChanged?.Invoke(SaveManager.Instance.CurrentSaveData.Gems);
        }

        public bool TrySpendCoins(int cost)
        {
            if (SaveManager.Instance.CurrentSaveData.Coins >= cost)
            {
                SaveManager.Instance.CurrentSaveData.Coins -= cost;
                SaveManager.Instance.SaveGame();
                OnCoinsChanged?.Invoke(SaveManager.Instance.CurrentSaveData.Coins);
                return true; // Purchase Successful
            }
            return false; // Not enough money
        }

        public bool TrySpendGems(int cost)
        {
            if (SaveManager.Instance.CurrentSaveData.Gems >= cost)
            {
                SaveManager.Instance.CurrentSaveData.Gems -= cost;
                SaveManager.Instance.SaveGame();
                OnGemsChanged?.Invoke(SaveManager.Instance.CurrentSaveData.Gems);
                return true;
            }
            return false;
        }

        public int GetCurrentCoins() => SaveManager.Instance.CurrentSaveData.Coins;
        public int GetCurrentGems() => SaveManager.Instance.CurrentSaveData.Gems;
    }
}
