using System;
using UnityEngine;

public class SphereScaler : MonoBehaviour
{
    private Vector3 _originalScale;

    [SerializeField] private float _maxScale = 3.0f;
    [SerializeField] private BreathingLevel _breathingLevel;


    private float _growSpeed = 2.0f;
    private float _minScale = 0.1f;


    private void Start()
    {
        SetSphereScale();
    }    

    private void Update()
    {
        InputHandler();
    }

    private void GetMaxScale()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, _originalScale * _maxScale, _growSpeed * Time.deltaTime);
    }

    private void GetMinScale()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, _originalScale * _minScale, _minScale * Time.deltaTime);
    }   

    private void SetSphereScale()
    {
        _originalScale = transform.localScale;
    }  
    
    private void InputHandler()
    {
        if (_breathingLevel._isPauseOn == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                GetMaxScale();
            else
                GetMinScale();
        }                
    }
}
