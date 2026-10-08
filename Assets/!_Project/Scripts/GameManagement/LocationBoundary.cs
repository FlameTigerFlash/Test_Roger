using UnityEngine;

public class LocationBoundary : MonoBehaviour
{
    [SerializeField] private Vector2 _center = Vector2.zero;
    [SerializeField] private Vector2 _size = new Vector2(50f, 50f);

    public Vector2 Center => _center;

    public Vector2 Size
    {
        get => _size;
        set => _size = new Vector2(Mathf.Abs(value.x), Mathf.Abs(value.y));
    }

    public bool IsInside(Vector3 worldPosition)
    {
        float halfX = _size.x * 0.5f;
        float halfZ = _size.y * 0.5f;

        float dx = worldPosition.x - _center.x;
        float dz = worldPosition.z - _center.y;

        return Mathf.Abs(dx) <= halfX && Mathf.Abs(dz) <= halfZ;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Vector3 a = new Vector3(_center.x - _size.x * 0.5f, 0f, _center.y - _size.y * 0.5f);
        Vector3 b = new Vector3(_center.x + _size.x * 0.5f, 0f, _center.y - _size.y * 0.5f);
        Vector3 c = new Vector3(_center.x + _size.x * 0.5f, 0f, _center.y + _size.y * 0.5f);
        Vector3 d = new Vector3(_center.x - _size.x * 0.5f, 0f, _center.y + _size.y * 0.5f);

        Gizmos.DrawLine(a, b);
        Gizmos.DrawLine(b, c);
        Gizmos.DrawLine(c, d);
        Gizmos.DrawLine(d, a);
    }
}