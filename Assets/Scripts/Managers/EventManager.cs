using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : CustomBehaviour
{

    public event Action OnGameStarted;
    public event Action OnGameFinished;

    public event Action OnGamePaused;
    public event Action OnGameResumed;

    public event Action OnCreditsShown;
    public event Action OnUpgradePanelShown;

    public event Action OnNewGameStarted;
    public event Action OnLevelLoaded;
    public event Action<int> OnLevelStarted;
    public event Action OnLevelCompleted;
    public event Action OnLevelFailed;

    public event Action<int> OnPlayerHit;
    public event Action OnPlayerKilled;
    public event Action<Vector3> OnBabyDelivered;
    public event Action<int> OnUseSkill;

    public event Action OnUpgradeHealth;
    public event Action OnUpgradeSpeed;
    public event Action OnUpgradeArmor;
    public event Action<int> OnGainSkill;

    public event Action OnPlayerStatsChanged;


    public void StartGame()
    {
        OnGameStarted?.Invoke();
    }

    public void FinishGame()
    {
        OnGameFinished?.Invoke();
    }

    public void PauseGame()
    {
        OnGamePaused?.Invoke();
    }

    public void ResumeGame()
    {
        OnGameResumed?.Invoke();
    }

    public void ShowCredits()
    {
        OnCreditsShown?.Invoke();
    }

    public void StartNewGame()
    {
        OnNewGameStarted?.Invoke();
    }

    public void LevelLoaded()
    {
        OnLevelLoaded?.Invoke();
    }

    public void StartLevel(int levelID)
    {
        OnLevelStarted?.Invoke(levelID);
    }

    public void CompleteLevel()
    {
        OnLevelCompleted?.Invoke();
    }

    public void FailLevel()
    {
        OnLevelFailed?.Invoke();
    }

    public void HitPlayer(int damage)
    {
        OnPlayerHit?.Invoke(damage);
    }

    public void KillPlayer()
    {
        OnPlayerKilled?.Invoke();
    }

    public void DeliverBaby(Vector3 target)
    {
        OnBabyDelivered?.Invoke(target);
    }

    public void UseSkill(int skillID)
    {
        OnUseSkill?.Invoke(skillID);
    }

    public void UpgradeHealth()
    {
        OnUpgradeHealth?.Invoke();
    }

    public void UpgradeSpeed()
    {
        OnUpgradeSpeed?.Invoke();
    }

    public void UpgradeArmor()
    {
        OnUpgradeArmor?.Invoke();
    }

    public void GainSkill(int skillID)
    {
        OnGainSkill?.Invoke(skillID);
    }

    public void ShowUpgradePanel()
    {
        OnUpgradePanelShown?.Invoke();  
    }

    public void UpdatePlayerStats()
    {
        OnPlayerStatsChanged?.Invoke();
    }
}
