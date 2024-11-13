using UnityEngine;
using System.Collections;

public class Breathing : MonoBehaviour
{
    [SerializeField] private Transform _breathing;
    [SerializeField] private float _minScaleX = 0.01f;
    [SerializeField] private float _animationDuration = 0.4f;

    public Vector3 startScale;

    private void Start()
    {
        startScale = _breathing.localScale;
    }

    private void OnEnable()
    {
        InputManager.Instance.OnSpacePressed += StartBreathingAnimation;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnSpacePressed -= StartBreathingAnimation;
    }

    private void StartBreathingAnimation()
    {
        StartCoroutine(BreathingAnimation());
    }

    private IEnumerator BreathingAnimation()
    {
        _breathing.localScale = new Vector3(_minScaleX, startScale.y, startScale.z);
        yield return new WaitForSeconds(_animationDuration);

        float elapsedTime = 0f;
        while (elapsedTime < _animationDuration)
        {
            _breathing.localScale = Vector3.Lerp(new Vector3(_minScaleX, startScale.y, startScale.z), startScale, elapsedTime / _animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _breathing.localScale = startScale;
    }
}
