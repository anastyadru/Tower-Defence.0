using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameM : MonoBehaviour
{
    [SerializeField] private Text _healthText;
    [SerializeField] private int _health = 100;

	[SerializeField] private Text _goldText;

	[SerializeField] private Enemy _enemy;
	[SerializeField] private GameObject _startCube;
	[SerializeField] private Text _waveText;
	[SerializeField] private Text _waveTimeText;

	[SerializeField] private int _wavesCount = 10;
	[SerializeField] private float _nextWaveTime = 10;
	[SerializeField] private float _spawnInterval = 1;
	[SerializeField] private float _startTime = 5;
	
	[SerializeField] private GameObject _bullet;
    
    public int _gold = 150;
	public int _playerCost = 50;

	private int[] _enemyCounts = new int[] { 4, 5, 6, 3, 2, 7, 8, 4, 9, 10 };
	private int _waveIndex;
	private bool _endGame;

	public static GameM instance;

    private void Start()
    {
        instance = this;
        
        _healthText.text = "Health: " + _health;
		_waveText.gameObject.SetActive(false);

		UpdateGold();
    }

	public void Update()
	{
		Enemy[] enemies = FindObjectsOfType<Enemy>();
		
		if(_waveIndex >= _wavesCount && enemies.Length == 0 && !_endGame)
		{
			_endGame = true;
			Debug.Log("Victory!");
			Time.timeScale = 0;
		}

		if(_waveIndex >= _wavesCount)
		{
			_waveTimeText.gameObject.SetActive(false);
			return;
		}

		if(_startTime <= 0)
		{
			StartCoroutine(Spawn());
			_startTime = _nextWaveTime;
		}

		_startTime -= Time.deltaTime;
		_startTime = Mathf.Clamp(_startTime, 0, Mathf.Infinity);
		_waveTimeText.text = string.Format("{0:00.00}", _startTime);
		if(_waveIndex > 0)
		{
			_waveText.gameObject.SetActive(true);
			_waveText.text = _waveIndex + "/" + _wavesCount + " Wave";
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
        }

        _healthText.text = "Health: " + _health;
    }

	IEnumerator Spawn()
	{
		if (_waveIndex < _enemyCounts.Length)
		{
			for (int i = 0; i < _enemyCounts[_waveIndex]; i++)
			{
				Bullet bullet = Instantiate(_bullet, _startCube.transform.position, _bullet.transform.rotation).GetComponent<Bullet>();
				bullet.Find(_enemy.transform, _waveIndex); // Передаем текущий индекс волны
				yield return new WaitForSeconds(_spawnInterval);
			}
			_waveIndex++;
		}
	}
}