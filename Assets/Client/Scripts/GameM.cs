using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameM : MonoBehaviour
{
    [SerializeField] private Text _healthText;
    [SerializeField] private int _health = 100;
    
    public static GameM instance;

    private void Start()
    {
        instance = this;
        
        _healthText.text = _health.ToString();
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