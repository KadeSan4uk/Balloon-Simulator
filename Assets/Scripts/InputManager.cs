using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public Balloon ballon;
    public Button spaceButton;

    public event Action OnSpacePressed;

    [SerializeField] private float _cooldownTime;

    public bool _onClickButton = false;
    public bool isOnCooldown = false;

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
        if (isOnCooldown) return;

        if (Input.GetKeyDown(KeyCode.Space) && !isOnCooldown || _onClickButton && !isOnCooldown)
        {
            OnSpacePressed?.Invoke();
            ballon.IsGameStarted = true;
            _onClickButton = false;
            StartCoroutine(StartCooldown());
        }
    }
    public void OnClickButtoon()
    {
        _onClickButton = true;
        ballon.IsGameStarted = true;
    }

    private IEnumerator StartCooldown()
    {
        isOnCooldown = true;
        spaceButton.interactable = false;
        yield return new WaitForSeconds(_cooldownTime);
        spaceButton.interactable = true;
        isOnCooldown = false;
    }
}
