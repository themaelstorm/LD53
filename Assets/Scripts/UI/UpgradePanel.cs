using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class UpgradePanel : UIPanel
{

    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _armorText;
    [SerializeField] private TMP_Text _speedText;
    [SerializeField] private TMP_Text _pointsText;

    [SerializeField] private int _upgradePointsMax;
    [SerializeField] private int _upgradePointsLeft;

    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);
        _gameManager.Events.OnUpgradePanelShown += ShowPanel;
        _gameManager.Events.OnPlayerStatsChanged += UpdateStats;

    }

    private void OnDestroy()
    {
        _gameManager.Events.OnUpgradePanelShown -= ShowPanel;
        _gameManager.Events.OnPlayerStatsChanged -= UpdateStats;
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
        _upgradePointsLeft = _upgradePointsMax;
        _pointsText.text = _upgradePointsLeft.ToString();
        _healthText.text = _gameManager.Stork.MaxHealth.ToString();
        _armorText.text = _gameManager.Stork.Armor.ToString();
        _speedText.text = _gameManager.Stork.Speed.ToString();
    }

    private void UpdateStats()
    {
        _pointsText.text = _upgradePointsLeft.ToString();
        _healthText.text = _gameManager.Stork.MaxHealth.ToString();
        _armorText.text = _gameManager.Stork.Armor.ToString();
        _speedText.text = _gameManager.Stork.Speed.ToString();
    }

    public void Upgrade(int upgradeID)
    {
        if (_upgradePointsLeft > 0)
        {
            _upgradePointsLeft -= 1;
            _pointsText.text = _upgradePointsLeft.ToString();
            _gameManager.Events.GainSkill(upgradeID);
        }
    }

    public void PlayNextLevel()
    {
        _gameManager.Levels.PlayNextLevel();
        HidePanel();
    }
}
