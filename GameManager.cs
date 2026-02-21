using UnityEngine;
using System;

namespace DesiShadow.Core
{
    public enum GameState { MainMenu, Playing, Paused, GameOver }

    public class GameManager : Singleton<GameManager>
    {
        public GameState CurrentState { get; private set; }

        public static event Action<GameState> OnGameStateChanged;

        protected override void Awake()
        {
            base.Awake();
            Application.targetFrameRate = 60; // Mobile optimization target
        }

        private void Start()
        {
            ChangeState(GameState.MainMenu);
        }

        public void ChangeState(GameState newState)
        {
            CurrentState = newState;
            
            switch (newState)
            {
                case GameState.MainMenu:
                    Time.timeScale = 1;
                    break;
                case GameState.Playing:
                    Time.timeScale = 1;
                    break;
                case GameState.Paused:
                    Time.timeScale = 0; // Freeze game
                    break;
                case GameState.GameOver:
                    Time.timeScale = 1; // Keep 1 if you want slow-mo death effects
                    break;
            }

            OnGameStateChanged?.Invoke(newState);
            Debug.Log($"Game State Changed to: {newState}");
        }

        public void StartLevel(string levelName)
        {
            // Logic to load scene would go here
            ChangeState(GameState.Playing);
        }
    }
}
