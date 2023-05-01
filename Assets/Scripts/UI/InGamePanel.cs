using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGamePanel : UIPanel
{
    [SerializeField] private bool _isPaused;

    [SerializeField] private TMP_Text _actionButtonText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _babyDeliverText;

    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);

        _gameManager.Events.OnLevelLoaded += ShowPanel;
        _gameManager.Events.OnLevelFailed += HidePanel;
        _gameManager.Events.OnLevelCompleted += HidePanel;

        _gameManager.Events.OnPlayerStatsChanged += UpdateStats;
    }

    private void OnDestroy()
    {
        _gameManager.Events.OnLevelLoaded -= ShowPanel;
        _gameManager.Events.OnLevelFailed -= HidePanel;
        _gameManager.Events.OnLevelCompleted -= HidePanel;

        _gameManager.Events.OnPlayerStatsChanged -= UpdateStats;

    }

    public override void ShowPanel()
    {
        base.ShowPanel();
        _isPaused = true;
        _actionButtonText.text = "Resume";
        UpdateStats();
    }

    private void UpdateStats()
    {
        if (_gameManager.Stork != null)
            _healthText.text = _gameManager.Stork.CurrentHealth.ToString() + " / " + _gameManager.Stork.MaxHealth.ToString();
        if (_gameManager.Levels.CurrentLevel != null)
            _babyDeliverText.text = _gameManager.Levels.CurrentLevel.DeliveryMade.ToString() + " / " + _gameManager.Levels.CurrentLevel.BabyDeliveryCount.ToString();
    }


    public void PauseResume()
    {
        if (_isPaused)
        {
            _actionButtonText.text = "Pause";
            _isPaused = false;
            _gameManager.Events.ResumeGame();
        }
        else
        {
            _actionButtonText.text = "Resume";
            _isPaused = true;
            _gameManager.Events.PauseGame();
        }
    }


}
