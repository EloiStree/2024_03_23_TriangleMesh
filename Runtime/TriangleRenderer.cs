using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TriangleRenderer : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;

    private Mesh mesh;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    void Update()
    {
        if (point1 != null && point2 != null && point3 != null)
        {
            UpdateTriangle();
        }
    }

    void UpdateTriangle()
    {
        Vector3[] vertices = new Vector3[]
        {
            point1.position,
            point2.position,
            point3.position
        };

        // Convert local positions to world positions
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = transform.InverseTransformPoint(vertices[i]);
        }

        int[] triangles = new int[] { 0, 1, 2 };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    void OnDrawGizmosSelected()
    {
        if (point1 != null && point2 != null && point3 != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(point1.position, 0.1f);
            Gizmos.DrawSphere(point2.position, 0.1f);
            Gizmos.DrawSphere(point3.position, 0.1f);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(point1.position, point2.position);
            Gizmos.DrawLine(point2.position, point3.position);
            Gizmos.DrawLine(point3.position, point1.position);
        }
    }
}
