using System;
using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public event Action OnSpacePressed;

    [SerializeField] private float _cooldownTime = 1f;
    public bool _onClickButton = false;
    private bool _isOnCooldown = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isOnCooldown || _onClickButton && !_isOnCooldown)
        {
            OnSpacePressed?.Invoke();
            StartCoroutine(StartCooldown());
            _onClickButton = false;
        }
    }
    public void OnClickButtoon()
    {
        _onClickButton = true;
    }

    private IEnumerator StartCooldown()
    {
        _isOnCooldown = true;
        yield return new WaitForSeconds(_cooldownTime);
        _isOnCooldown = false;
    }
}
