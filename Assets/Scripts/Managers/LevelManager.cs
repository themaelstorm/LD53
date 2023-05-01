using UnityEngine;

public class LevelManager : CustomBehaviour
{
    [SerializeField] private GameObject[] _levelPrefabs;

    public Level CurrentLevel;
    [SerializeField] private int _currentLevelID;

    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);

        _gameManager.Events.OnLevelStarted += LoadLevel;
        _gameManager.Events.OnLevelCompleted += ClearLevel;
        _gameManager.Events.OnLevelFailed += ClearLevel;

    }

    private void OnDestroy()
    {
        _gameManager.Events.OnLevelStarted -= LoadLevel;
        _gameManager.Events.OnLevelCompleted -= ClearLevel;
        _gameManager.Events.OnLevelFailed -= ClearLevel;
    }

    private void ClearLevel()
    {
        Destroy(CurrentLevel.gameObject);
        CurrentLevel = null;
    }

    private void LoadLevel(int levelID)
    {
        _currentLevelID = levelID;

        GameObject go = Instantiate(_levelPrefabs[levelID], Vector3.zero, Quaternion.identity);
        CurrentLevel = go.GetComponent<Level>();
        CurrentLevel.Init(_gameManager);

        _gameManager.Events.LevelLoaded();
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

    /*
    public void AddAgent(CustomAgent agent)
    {
        _currentLevel.Agents.Add(agent);
    }

    public void RemoveAgent(CustomAgent agent)
    {
        if (_currentLevel.Agents.Contains(agent))
            _currentLevel.Agents.Remove(agent);
    }
    */
}
