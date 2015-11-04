using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]

public class Chunk : MonoBehaviour
{
    
    public static int CHUNK_SIZE = 16;
    public bool update = true;
    Block[,,] blocks;

    MeshFilter filter;
    MeshCollider coll;

    // Use this for initialization
    void Start()
    {
        filter = gameObject.GetComponent<MeshFilter>();
        coll = gameObject.GetComponent<MeshCollider>();

        blocks = new Block[CHUNK_SIZE, CHUNK_SIZE, CHUNK_SIZE];

        for (int x = 0; x < CHUNK_SIZE; x++)
        {
            for (int y = 0; y < CHUNK_SIZE; y++)
            {
                for (int z = 0; z < CHUNK_SIZE; z++)
                {
                    blocks[x, y, z] = new BlockAir();
                }
            }
        }

        blocks[3, 5, 2] = new Block();
        blocks[4, 5, 2] = new BlockGrass();

        UpdateChunk();
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    public Block GetBlock(int x, int y, int z)
    {
        return blocks [x, y, z];
    }

    void UpdateChunk()
    {
        MeshData meshData = new MeshData();

        for (int x = 0; x < CHUNK_SIZE; x++)
        {
            for (int y = 0; y < CHUNK_SIZE; y++)
            {
                for (int z = 0; z < CHUNK_SIZE; z++)
                {
                    meshData = blocks[x, y, z].Blockdata(this, x, y, z, meshData);
                }
            }
        }

        RenderMesh(meshData);
    }

    void RenderMesh(MeshData meshData)
    {
        filter.mesh.Clear();
        filter.mesh.vertices = meshData.vertices.ToArray();
        filter.mesh.triangles = meshData.triangles.ToArray();
        filter.mesh.uv = meshData.uv.ToArray();
        filter.mesh.RecalculateNormals();

        coll.sharedMesh = null;
        Mesh mesh = new Mesh();
        mesh.vertices = meshData.colVertices.ToArray();
        mesh.triangles = meshData.colTriangles.ToArray();
        mesh.RecalculateNormals();
        coll.sharedMesh = mesh;
    }
}
