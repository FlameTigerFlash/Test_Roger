using UnityEngine;

public class LocationBoundaryRenderer : MonoBehaviour
{
    [SerializeField] private LocationBoundary _boundary;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _lineHeight = 0.1f;

    private void Start()
    {
        Rebuild();
    }

    private void OnValidate()
    {
        if (_boundary != null && _lineRenderer != null)
            Rebuild();
    }

    private void Rebuild()
    {
        if (_boundary == null || _lineRenderer == null) return;

        Vector2 center = _boundary.Center;
        Vector2 size = _boundary.Size;

        float halfX = size.x * 0.5f;
        float halfZ = size.y * 0.5f;

        _lineRenderer.positionCount = 4;
        _lineRenderer.loop = true;
        _lineRenderer.useWorldSpace = true;

        _lineRenderer.SetPosition(0, new Vector3(center.x - halfX, _lineHeight, center.y - halfZ));
        _lineRenderer.SetPosition(1, new Vector3(center.x + halfX, _lineHeight, center.y - halfZ));
        _lineRenderer.SetPosition(2, new Vector3(center.x + halfX, _lineHeight, center.y + halfZ));
        _lineRenderer.SetPosition(3, new Vector3(center.x - halfX, _lineHeight, center.y + halfZ));
    }
}