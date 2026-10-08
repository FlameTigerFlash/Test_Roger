using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestarter : MonoBehaviour
{
    [SerializeField] private LocationExitController _controller;
    [SerializeField] private float _restartDelay = 1f;

    private void OnEnable()
    {
        if (_controller != null)
            _controller.OnLocationExit.AddListener(HandleLocationExit);
    }

    private void OnDisable()
    {
        if (_controller != null)
            _controller.OnLocationExit.RemoveListener(HandleLocationExit);
    }

    private void HandleLocationExit()
    {
        StartCoroutine(RestartRoutine());
    }

    private IEnumerator RestartRoutine()
    {
        yield return new WaitForSeconds(_restartDelay);

        if (_controller != null && !_controller.IsOutside)
            yield break;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}