using UnityEngine;
using System.Collections;

public class BreathingLevel : MonoBehaviour
{
    private Vector3 _originalScale;
    private float _maxBreathingScale = 1.0f;
    private float _minBreathingScale = 0.5f;
    private float _partOfSpace = 0.5f;
    private float _growSpeed = 0.8f;
    public bool _isPauseOn = false;

    void Start()
    {
        SetBreathingLevelScale();
    }

    void Update()
    {
        BreathingLevelScaller();

        StartCoroutine(CheckAndPauseIfMinSize(this.gameObject));
    }

    private void SetBreathingLevelScale()
    {
        _originalScale = transform.localScale;
    }

    private void GetMaxScale()
    {
        Vector3 currentScale = transform.localScale;
        float targetYScale = Mathf.Lerp(currentScale.y, _originalScale.y * _maxBreathingScale, _growSpeed * Time.deltaTime);
        transform.localScale = new Vector3(currentScale.x, targetYScale, currentScale.z);
    }

    private void GetMinScale()
    {
        Vector3 currentScale = transform.localScale;
        float newYScale = Mathf.Max(currentScale.y - _partOfSpace, 0);
        transform.localScale = new Vector3(currentScale.x, newYScale, currentScale.z);
    }

    private void BreathingLevelScaller()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GetMinScale();
        else
            GetMaxScale();
    }

    private IEnumerator CheckAndPauseIfMinSize(GameObject obj)
    {
        if (obj.transform.localScale.magnitude <= _minBreathingScale)
        {
            Debug.Log("Breathing is over. Pause for 2 second.");
            yield return new WaitForSeconds(2);
            _isPauseOn=true;
        }
    }
}
