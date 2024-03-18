using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameM : MonoBehaviour
{
    public static GameM instance;
    [SerializeField] private Text _healthText;
    [SerializeField] private int _health = 100;

    private void Start()
    {
        instance = this;
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