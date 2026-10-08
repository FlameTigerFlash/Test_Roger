using System;
using UnityEngine;
using UnityEngine.Events;

public class LocationExitController : MonoBehaviour
{
    [SerializeField] private Transform _ship;
    [SerializeField] private LocationBoundary _boundary;
    [SerializeField] private float _graceSeconds = 1f;
    [SerializeField] private float _countdownSeconds = 5f;

    [SerializeField] private UnityEvent _onLocationExit;

    public UnityEvent OnLocationExit => _onLocationExit;

    public event Action OnBoundaryExit;
    public event Action OnBoundaryReturn;

    public bool IsOutside { get; private set; }
    public bool WarningShown { get; private set; }
    public float RemainingSeconds { get; private set; }

    private Coroutine _routine;

    private void Update()
    {
        if (_ship == null || _boundary == null) return;

        bool inside = _boundary.IsInside(_ship.position);

        if (inside && IsOutside)
        {
            // вернулись внутрь
            IsOutside = false;
            WarningShown = false;
            RemainingSeconds = 0f;
            StopRoutine();
            OnBoundaryReturn?.Invoke();
        }
        else if (!inside && !IsOutside)
        {
            // только что вышли
            IsOutside = true;
            WarningShown = false;
            RemainingSeconds = 0f;
            StopRoutine();
            _routine = StartCoroutine(ExitRoutine());
            OnBoundaryExit?.Invoke();
        }
    }

    private System.Collections.IEnumerator ExitRoutine()
    {
        // 1 секунда до предупреждения
        yield return new WaitForSeconds(_graceSeconds);

        if (!IsOutside) yield break;

        WarningShown = true;
        RemainingSeconds = _countdownSeconds;

        while (RemainingSeconds > 0f)
        {
            if (!IsOutside) yield break;
            RemainingSeconds -= Time.deltaTime;
            yield return null;
        }

        RemainingSeconds = 0f;
        WarningShown = false;

        // событие выхода
        _onLocationExit?.Invoke();
        Debug.Log("Location exited");

        // после вызова остаёмся в состоянии IsOutside == true.
        // Если корабль вернётся — Update переведёт в Inside и вызовет OnBoundaryReturn.
        _routine = null;
    }

    private void StopRoutine()
    {
        if (_routine != null)
        {
            StopCoroutine(_routine);
            _routine = null;
        }
    }
}