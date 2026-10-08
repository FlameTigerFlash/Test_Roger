using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class SeaFollow : MonoBehaviour
{
    [SerializeField, NotNull] private Transform _shipTransform;
    [SerializeField, NotNull] private Transform _seaTransform;

    private void OnValidate()
    {
        if (_seaTransform == null)
        {
            _seaTransform = transform;
        }
    }

    private void LateUpdate()
    {
        _seaTransform.position = new Vector3(_shipTransform.position.x, _seaTransform.position.y, _shipTransform.position.z);
    }
}
