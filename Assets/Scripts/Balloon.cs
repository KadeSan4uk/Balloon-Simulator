using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Balloon : MonoBehaviour
{
    public Action OnExplosion;    

    [SerializeField] private Transform _balloon;
    [SerializeField] private float _maxScale;
    [SerializeField] private float _blowingPower;
    [SerializeField] private float _minScale;
    [SerializeField] private float _blowingAwayPower;


    private void Start()
    {
        OnExplosion += Explode;
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameOver())
            return;

        _balloon.localScale -= Vector3.one * _blowingAwayPower * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _balloon.localScale += Vector3.one * _blowingPower;
        }

        if (_balloon.localScale.x >= _maxScale || _balloon.localScale.x <= _minScale)
        {
            OnExplosion?.Invoke();
            GameManager.Instance.EndGame();
        }
    }

    private void Explode()
    {
        OnExplosion -= Explode;
        GameManager.Instance.EndGame();
        Destroy(gameObject);       
    }
}
