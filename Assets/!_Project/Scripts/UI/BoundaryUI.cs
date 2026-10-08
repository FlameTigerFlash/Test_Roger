using TMPro;
using UnityEngine;

public class BoundaryUI : MonoBehaviour
{
    [SerializeField] private LocationExitController _controller;
    [SerializeField] private GameObject _warningRoot;
    [SerializeField] private TMP_Text _warningLabel;
    [SerializeField] private TMP_Text _countdownLabel;

    private void Update()
    {
        if (_controller == null) return;

        bool shown = _controller.WarningShown;

        if (_warningRoot != null && _warningRoot.activeSelf != shown)
            _warningRoot.SetActive(shown);

        if (!shown) return;

        if (_warningLabel != null)
            _warningLabel.text = "Attention! You are leaving the area!";

        if (_countdownLabel != null)
        {
            int seconds = Mathf.CeilToInt(_controller.RemainingSeconds);
            _countdownLabel.text = seconds.ToString();
        }
    }
}