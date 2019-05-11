using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class MapEditor : MonoBehaviour
{
    public enum WallDir
    {
        Up,
        Down,
        Right,
        Left,
        Forward
    }

    //[HideInInspector]
    [Range(0, 100)]
    public int Width;
    [Range(0,100)]
    public int Height;

    private Mesh mesh;
    private List<Vector3> verties;
    private List<int> triangles;
    private List<Vector2> UVs;
    private BoxCollider boxCollider;

    private void Awake()
    {
        EdgesInit();
        mesh = new Mesh();
        verties = new List<Vector3>();
        triangles = new List<int>();
        UVs = new List<Vector2>();
    }

    public void EdgesInit()
    {
        Width = 0;
        Height = 0;
    }

    public void GenerateMesh()
    {
        ClearAll();
        GenerateSurface();
        ApplySurface();
        ApplyCollider();
    }

    private void ClearAll()
    {
        mesh.Clear();
        verties.Clear();
        triangles.Clear();
        UVs.Clear();
    }

    private void ApplySurface()
    {
        if(mesh == null)
        {
            mesh = new Mesh();
        }
        mesh.SetVertices(verties);
        mesh.SetTriangles(triangles, 0);
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.SetUVs(0, UVs);
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void ApplyCollider()
    {
        boxCollider = GetComponent<BoxCollider>();
        if (boxCollider)
        {
            Bounds bounds = mesh.bounds;
            boxCollider.center = new Vector3(0, 0, 0.5f);
            boxCollider.size = bounds.extents * 2.0f;
        }
    }

    private void GenerateSurface()
    {
        float iWidth = Width;
        float iHeight = Height;
        Vector3 basePoint = new Vector3(-iWidth / 2.0f, -iHeight / 2.0f, 0.0f);

        for (int j = 0; j < iHeight; j++)
        {
            for (int i = 0; i < iWidth; i++)
            {
                AddQuad(basePoint + new Vector3(i, j, 0),
                    basePoint + new Vector3(i, j + 1, 0),
                    basePoint + new Vector3(i + 1, j + 1, 0),
                    basePoint + new Vector3(i + 1, j, 0),WallDir.Forward);
            }
        }

        for(int i = 0; i < iWidth; i++)
        {
            AddQuad(basePoint + new Vector3(i, iHeight, 0), 
                basePoint + new Vector3(i, iHeight, 1), 
                basePoint + new Vector3(i + 1, iHeight, 1), 
                basePoint + new Vector3(i + 1, iHeight, 0), WallDir.Up);

            AddQuad(basePoint + new Vector3(i, 0, 1),
                basePoint + new Vector3(i, 0, 0),
                basePoint + new Vector3(i + 1, 0, 0),
                basePoint + new Vector3(i + 1, 0, 1), WallDir.Down);
        }

        for(int i = 0; i < iHeight; i++)
        {
            AddQuad(basePoint + new Vector3(0, i, 0), 
                basePoint + new Vector3(0, i, 1), 
                basePoint + new Vector3(0, i+1, 1), 
                basePoint + new Vector3(0, i+1, 0), WallDir.Left);

            AddQuad(basePoint + new Vector3(iWidth, i, 0),
                basePoint + new Vector3(iWidth, i + 1, 0),
                basePoint + new Vector3(iWidth, i + 1, 1),
                basePoint + new Vector3(iWidth, i, 1), WallDir.Right);
        }
    }

    private void AddQuad(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4, WallDir dir)
    {
        int vertexIndex = verties.Count;
        verties.Add(v1);
        verties.Add(v2);
        verties.Add(v3);
        verties.Add(v4);
        triangles.Add(vertexIndex); triangles.Add(vertexIndex + 1); triangles.Add(vertexIndex + 2);
        triangles.Add(vertexIndex); triangles.Add(vertexIndex + 2); triangles.Add(vertexIndex + 3);
        AddQuadUV(dir);
    }

    private void AddQuadUV(WallDir dir)
    {
        float delta = 1f / 3f;
        Vector2 basePoint = Vector2.zero;
        float RandX = Mathf.Floor(Random.Range(0,4)) * 0.25f;
        switch (dir)
        {
            case WallDir.Forward:
                basePoint = new Vector2(RandX, delta);
                break;
            case WallDir.Up:
                basePoint = new Vector2(RandX, delta * 2f);
                break;
            case WallDir.Down:
                basePoint = new Vector2(RandX, 0f);
                break;
            case WallDir.Right:
                basePoint = new Vector2(RandX, delta * 2f);
                break;
            case WallDir.Left:
                basePoint = new Vector2(RandX, delta * 2f);
                break;
            default:
                break;
        }
        UVs.Add(basePoint);
        UVs.Add(basePoint + new Vector2(0, delta));
        UVs.Add(basePoint + new Vector2(0.25f, delta));
        UVs.Add(basePoint + new Vector2(0.25f, 0));
    }
}
