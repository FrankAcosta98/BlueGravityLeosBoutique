using UnityEngine;
public sealed class DebugBoxCollider2DGizmo : MonoBehaviour
{
    public Color boxColor=Color.red;
    void OnDrawGizmos()
    {
        var boxCollider = GetComponent<BoxCollider2D>();
        Gizmos.color = boxColor;
        //Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size );
        Gizmos.DrawCube(boxCollider.bounds.center, boxCollider.bounds.size);
    }
}