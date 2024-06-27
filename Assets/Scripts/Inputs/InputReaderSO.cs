using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
[CreateAssetMenu(fileName = "InputReaderSO", menuName = "Scriptable Objects/InputReaderSO")]
public class InputReaderSO : ScriptableObject
{
    public event Action OnTouchStart;
    public event Action OnTouchEnded;
    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += StartTouch;
        EnhancedTouch.Touch.onFingerUp += EndTouch;
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
    }
    private void StartTouch(Finger finger)
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
            OnTouchStart?.Invoke();
    }

    private void EndTouch(Finger finger)
    {
        OnTouchEnded?.Invoke();
    }
}
