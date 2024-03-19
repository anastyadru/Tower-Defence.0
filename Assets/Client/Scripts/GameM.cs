using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameM : MonoBehaviour
{
    [SerializeField] private Text _healthText;
    [SerializeField] private int _health = 100;
	[Space(5)]
	[SerializeField] private Enemy _enemy;
	[SerializeField] private GameObject _startCube;
	[SerializeField] private Text _waveText;
	[SerializeField] private Text _waveTimeText;
	[Space(5)]
	[SerializeField] private int _wavesCount = 5;
	[SerializeField] private float _nextWaveTime = 10;
	[SerializeField] private float _spawnInterval = 1;
	[SerializeField] private float _startTime = 5;
    
    public static GameM instance;

	private int _waveIndex;
	private bool _endGame;

    private void Start()
    {
        instance = this;
        
        _healthText.text = _health.ToString();
		_waveText.gameObject.SetActive(false);
    }

	public void Update()
	{
		Enemy[] enemies = FindObjectOfType<Enemy>();
		
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
	}

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Debug.Log("Defeat");
        }

        _healthText.text = _health.ToString();
    }
}