using UnityEngine;

public class SphereScaler : MonoBehaviour
{
    private Vector3 _originalScale;
    private float _growSpeed = 2.0f;
    private float _minScale = 0.1f;
    private float _maxScale = 4.0f;

    private void Start()
    {
        _originalScale = transform.localScale;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _originalScale * _maxScale, _growSpeed * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _originalScale * _minScale, _minScale * Time.deltaTime);
        }
    }
}
