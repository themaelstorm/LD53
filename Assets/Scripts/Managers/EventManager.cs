using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : CustomBehaviour
{

    public event Action OnGameStarted;
    public event Action OnGameFinished;

    public event Action OnCreditsShown;
    public event Action OnCreditsHide;

    public event Action OnInstructionsShown;
    public event Action OnInstructionsHide;

    public event Action OnNewGameStarted;
    public event Action OnLevelLoaded;
    public event Action<int> OnLevelStarted;
    public event Action OnLevelCompleted;
    public event Action OnLevelFailed;

    public event Action OnPlayerHit;
    public event Action OnPlayerKilled;
    public event Action OnBabyDelivered;
    public event Action<int> OnUseSkill;

    public event Action OnUpgradeHealth;
    public event Action OnUpgradeSpeed;
    public event Action OnUpgradeArmor;
    public event Action<int> OnGainSkill;


    public void StartGame()
    {
        OnGameStarted?.Invoke();
    }

    public void FinishGame()
    {
        OnGameFinished?.Invoke();
    }

    public void ShowCredits()
    {
        OnCreditsShown?.Invoke();
    }

    public void HideCredits()
    {
        OnCreditsHide?.Invoke();
    }

    public void ShowInstructions()
    {
        OnInstructionsShown?.Invoke();
    }

    public void HideInstructions()
    {
        OnInstructionsHide?.Invoke();
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

    public void HitPlayer()
    {
        OnPlayerHit?.Invoke();
    }

    public void KillPlayer()
    {
        OnPlayerKilled?.Invoke();
    }

    public void DeliverBaby()
    {
        OnBabyDelivered?.Invoke();
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

}
