using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;
    private Rigidbody2D _rbBall;
    private void Start()
    {
        _rbBall = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        _inputReader.OnTouchStart += StartBall;
    }

    private void StartBall()
    {
        _rbBall.bodyType = RigidbodyType2D.Dynamic;
    }
}
