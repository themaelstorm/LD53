using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class LevelManager : CustomBehaviour
{
    [SerializeField] private GameObject[] _levelPrefabs;

    [SerializeField] private Level _currentLevel;
    [SerializeField] private int _currentLevelID;

    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);

        _gameManager.Events.OnLevelStarted += LoadLevel;
    }

    private void OnDestroy()
    {
        _gameManager.Events.OnLevelStarted -= LoadLevel;
    }

    private void LoadLevel(int levelID)
    {
        _currentLevelID = levelID;

        if (transform.childCount > 0)
            Destroy(transform.GetChild(0).gameObject);

        GameObject go = Instantiate(_levelPrefabs[levelID], Vector3.zero, Quaternion.identity);
        _currentLevel = go.GetComponent<Level>();
        _currentLevel.Init(_gameManager);

        _gameManager.Events.LevelLoaded();
    }

    public void Pause()
    {
        _currentLevel.Pause();
    }

    public void Resume()
    {
        _currentLevel.Resume();
    }

    public void PlayAgain()
    {
        _gameManager.Events.StartLevel(_currentLevelID);
    }

    public void PlayNextLevel()
    {
        _currentLevelID++;
        if (_currentLevelID >= _levelPrefabs.Length)
            _currentLevelID = 0;

        _gameManager.Events.StartLevel(_currentLevelID);
    }

    public void AddAgent(CustomAgent agent)
    {
        _currentLevel.Agents.Add(agent);
    }

    public void RemoveAgent(CustomAgent agent)
    {
        if (_currentLevel.Agents.Contains(agent))
            _currentLevel.Agents.Remove(agent);
    }
}
