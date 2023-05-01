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

        _gameManager.Events.OnPlayerStatsChanged -= UpdateText;
        _gameManager.Events.OnBabyDelivered -= UpdateText;

        _isPaused = true;
        _actionButtonText.text = "Resume";

        UpdateText();
    }

    private void OnDestroy()
    {
        _gameManager.Events.OnLevelLoaded -= ShowPanel;
        _gameManager.Events.OnLevelFailed -= HidePanel;
        _gameManager.Events.OnLevelCompleted -= HidePanel;

        _gameManager.Events.OnPlayerStatsChanged -= UpdateText;
        _gameManager.Events.OnBabyDelivered -= UpdateText;
    }

    private void UpdateText()
    {
        _healthText.text = _gameManager.Stork.CurrentHealth.ToString() + " / " + _gameManager.Stork.MaxHealth.ToString();
        _babyDeliverText.text = "0 / 0";
    }

    public void PauseResume()
    {
        if (_isPaused)
        {
            _actionButtonText.text = "Pause";
            _isPaused = false;
            _gameManager.ResumeGame();
        }
        else
        {
            _actionButtonText.text = "Resume";
            _isPaused = true;
            _gameManager.PauseGame();
        }
    }

    public void Pause()
    {
        _gameManager.PauseGame();
    }

    public void Resume()
    {
        _gameManager.ResumeGame();
    }


}
