using System;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public Action OnExplosion;

    [SerializeField] private Transform _balloon;
    [SerializeField] private float _maxScale;
    [SerializeField] private float _blowingPower;
    [SerializeField] private float _minScale;
    [SerializeField] private float _blowingAwayPower;

    public InputManager inputManager;

    public bool IsGameStarted = false;    
    
    private void Start()
    {
        Initialize();
    }

    private void OnDisable()
    {
        InputManager.Instance.OnSpacePressed -= IncreaseSize;
        OnExplosion -= Explode;
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameOver())
            return;

        CheckStartGame();

        if (IsGameStarted)
        {
            _balloon.localScale -= Vector3.one * _blowingAwayPower * Time.deltaTime;

            if (_balloon.localScale.x >= _maxScale || _balloon.localScale.x <= _minScale)
            {
                OnExplosion?.Invoke();
                GameManager.Instance.EndGame();
            }
        }
    }

    private void Explode()
    {
        GameManager.Instance.EndGame();
        _balloon.transform.gameObject.SetActive(false);
    }

    private void CheckStartGame()
    {
        if (inputManager.isOnCooldown) return;
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !IsGameStarted || inputManager._onClickButton && !IsGameStarted)
            {
                IsGameStarted = true;
            }
        }        
    }

    private void IncreaseSize()
    {
        _balloon.localScale += Vector3.one * _blowingPower;
    }

    internal void Initialize()
    {
        InputManager.Instance.OnSpacePressed += IncreaseSize;
        OnExplosion += Explode;
    }
}
