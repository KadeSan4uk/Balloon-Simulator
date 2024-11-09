using System;
using UnityEngine;

public class SphereScaler : MonoBehaviour
{
    private Vector3 _originalScale;

    [SerializeField] private float _maxScale = 10.0f;
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

    private void BlowUp()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, _originalScale * _maxScale, _growSpeed * Time.deltaTime);
    }

    private void BlowAway()
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
                BlowUp();
            else
                BlowAway();
        }                
    }
}
