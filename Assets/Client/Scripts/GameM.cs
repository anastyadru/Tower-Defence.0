// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameM : MonoBehaviour
{ 
  [SerializeField] private Text _healthText;
  [SerializeField] private int _health = 100;

  [SerializeField] private Text _goldText;

  [SerializeField] private Enemy _enemy;
  [SerializeField] private GameObject _startCube;
  [SerializeField] private Text _waveText;
  [SerializeField] private Text _waveTimeText;

  [SerializeField] private int _wavesCount = 16;
  [SerializeField] private float _nextWaveTime = 12;
  [SerializeField] private float _spawnInterval = 1;
  [SerializeField] private float _startTime = 5;
    
  public int _gold = 150;
  public int _playerCost = 50;

  private int[] _enemyCounts = new int[] { 4, 5, 6, 5, 2, 7, 8, 9, 3, 6, 9, 9, 9, 10, 8, 9 };
  private int _waveIndex;
  private bool _endGame;

  public static GameM instance;
  
  private bool _waveInProgress = false;
  private int _currentEnemyCountIndex = 0;

  private void Start()
  {
    instance = this;
        
    _healthText.text = "Health: " + _health;
    _waveText.gameObject.SetActive(false);
    _waveTimeText.gameObject.SetActive(false);

    UpdateGold();
  }

  public void Update()
  {
    Enemy[] enemies = FindObjectsOfType<Enemy>();
    
    if (_waveIndex >= _wavesCount && enemies.Length == 0 && !_endGame && _health > 0)
    {
      _endGame = true;
      Debug.Log("Victory!");
      Time.timeScale = 0;
      EndGame();
    }

    if(_waveIndex >= _wavesCount)
    {
      _waveTimeText.gameObject.SetActive(false);
      return;
    }

    if(_startTime <= 0)
    {
      StartCoroutine(Spawn(_enemyCounts[_currentEnemyCountIndex]));
      _startTime = _nextWaveTime;
    }

    _startTime -= Time.deltaTime;
    _startTime = Mathf.Clamp(_startTime, 0, Mathf.Infinity);
    _waveTimeText.text = string.Format("{0:00.00}", _startTime);
    
    if(_waveIndex >= 0)
    {
      _waveText.gameObject.SetActive(true);
      _waveText.text = (_waveIndex + 1) + "/" + _wavesCount + " Wave";
    }
  }

    public void UpdateGold()
  {
    _goldText.text = _gold + "C";
  }

  public void TakeDamage(int damage)
  {
    _health -= damage;
    if (_health <= 0)
    {
      _endGame = true;
      Debug.Log("Defeat");
      Time.timeScale = 0;
      EndGame2();
    }

    _healthText.text = "Health: " + _health;
  }

  IEnumerator Spawn(int enemyCount)
  {
    if (_waveIndex < _wavesCount)
    {
      for (int i = 0; i < enemyCount; i++)
      {
        Instantiate(_enemy, _startCube.transform.position, _enemy.transform.rotation);
        yield return new WaitForSeconds(_spawnInterval);
      }
      _waveIndex++;
    }
    _waveInProgress = false; // Устанавливаем флаг окончания волны после завершения спауна
  }
  
  public void StartNextWaveManually()
  {
    if (!_waveInProgress && _currentEnemyCountIndex < _enemyCounts.Length)
    {
      StartCoroutine(Spawn(_enemyCounts[_currentEnemyCountIndex])); // Запускаем новую волну с количеством врагов из массива
      _waveInProgress = true;
      _waveTimeText.gameObject.SetActive(true);
      _waveTimeText.text = string.Format("{0:00.00}", _nextWaveTime);
      _currentEnemyCountIndex++; // Увеличиваем индекс для следующей волны
    }
  }

  public void EndCurrentWave()
  {
    StopAllCoroutines();
    _waveIndex++;
    _waveInProgress = false;
    _waveTimeText.gameObject.SetActive(false);
    if (_waveIndex >= _wavesCount)
    {
      Debug.Log("All waves completed!");
      EndGame();
    }
  }
  
  public void EndGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
  
  public void EndGame2()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
  }
  
  public int GetCurrentWave()
  {
    return _waveIndex;
  }
}