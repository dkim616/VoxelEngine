﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadChunks : MonoBehaviour
{
    public World world;

    List<WorldPos> updateList = new List<WorldPos>();
    List<WorldPos> buildList = new List<WorldPos>();

	int timer = 0;

    static  WorldPos[] chunkPositions = {   
        new WorldPos( 0, 0,  0), new WorldPos(-1, 0,  0), new WorldPos( 0, 0, -1), new WorldPos( 0, 0,  1), new WorldPos( 1, 0,  0),
        new WorldPos(-1, 0, -1), new WorldPos(-1, 0,  1), new WorldPos( 1, 0, -1), new WorldPos( 1, 0,  1), new WorldPos(-2, 0,  0),
        new WorldPos( 0, 0, -2), new WorldPos( 0, 0,  2), new WorldPos( 2, 0,  0), new WorldPos(-2, 0, -1), new WorldPos(-2, 0,  1),
        new WorldPos(-1, 0, -2), new WorldPos(-1, 0,  2), new WorldPos( 1, 0, -2), new WorldPos( 1, 0,  2), new WorldPos( 2, 0, -1),
        new WorldPos( 2, 0,  1), new WorldPos(-2, 0, -2), new WorldPos(-2, 0,  2), new WorldPos( 2, 0, -2), new WorldPos( 2, 0,  2),
        new WorldPos(-3, 0,  0), new WorldPos( 0, 0, -3), new WorldPos( 0, 0,  3), new WorldPos( 3, 0,  0), new WorldPos(-3, 0, -1),
        new WorldPos(-3, 0,  1), new WorldPos(-1, 0, -3), new WorldPos(-1, 0,  3), new WorldPos( 1, 0, -3), new WorldPos( 1, 0,  3),
        new WorldPos( 3, 0, -1), new WorldPos( 3, 0,  1), new WorldPos(-3, 0, -2), new WorldPos(-3, 0,  2), new WorldPos(-2, 0, -3),
        new WorldPos(-2, 0,  3), new WorldPos( 2, 0, -3), new WorldPos( 2, 0,  3), new WorldPos( 3, 0, -2), new WorldPos( 3, 0,  2),
        new WorldPos(-4, 0,  0), new WorldPos( 0, 0, -4), new WorldPos( 0, 0,  4), new WorldPos( 4, 0,  0), new WorldPos(-4, 0, -1),
        new WorldPos(-4, 0,  1), new WorldPos(-1, 0, -4), new WorldPos(-1, 0,  4), new WorldPos( 1, 0, -4), new WorldPos( 1, 0,  4),
        new WorldPos( 4, 0, -1), new WorldPos( 4, 0,  1), new WorldPos(-3, 0, -3), new WorldPos(-3, 0,  3), new WorldPos( 3, 0, -3),
        new WorldPos( 3, 0,  3), new WorldPos(-4, 0, -2), new WorldPos(-4, 0,  2), new WorldPos(-2, 0, -4), new WorldPos(-2, 0,  4),
        new WorldPos( 2, 0, -4), new WorldPos( 2, 0,  4), new WorldPos( 4, 0, -2), new WorldPos( 4, 0,  2), new WorldPos(-5, 0,  0),
        new WorldPos(-4, 0, -3), new WorldPos(-4, 0,  3), new WorldPos(-3, 0, -4), new WorldPos(-3, 0,  4), new WorldPos( 0, 0, -5),
        new WorldPos( 0, 0,  5), new WorldPos( 3, 0, -4), new WorldPos( 3, 0,  4), new WorldPos( 4, 0, -3), new WorldPos( 4, 0,  3),
        new WorldPos( 5, 0,  0), new WorldPos(-5, 0, -1), new WorldPos(-5, 0,  1), new WorldPos(-1, 0, -5), new WorldPos(-1, 0,  5),
        new WorldPos( 1, 0, -5), new WorldPos( 1, 0,  5), new WorldPos( 5, 0, -1), new WorldPos( 5, 0,  1), new WorldPos(-5, 0, -2),
        new WorldPos(-5, 0,  2), new WorldPos(-2, 0, -5), new WorldPos(-2, 0,  5), new WorldPos( 2, 0, -5), new WorldPos( 2, 0,  5),
        new WorldPos( 5, 0, -2), new WorldPos( 5, 0,  2), new WorldPos(-4, 0, -4), new WorldPos(-4, 0,  4), new WorldPos( 4, 0, -4),
        new WorldPos( 4, 0,  4), new WorldPos(-5, 0, -3), new WorldPos(-5, 0,  3), new WorldPos(-3, 0, -5), new WorldPos(-3, 0,  5),
        new WorldPos( 3, 0, -5), new WorldPos( 3, 0,  5), new WorldPos( 5, 0, -3), new WorldPos( 5, 0,  3), new WorldPos(-6, 0,  0),
        new WorldPos( 0, 0, -6), new WorldPos( 0, 0,  6), new WorldPos( 6, 0,  0), new WorldPos(-6, 0, -1), new WorldPos(-6, 0,  1),
        new WorldPos(-1, 0, -6), new WorldPos(-1, 0,  6), new WorldPos( 1, 0, -6), new WorldPos( 1, 0,  6), new WorldPos( 6, 0, -1),
        new WorldPos( 6, 0,  1), new WorldPos(-6, 0, -2), new WorldPos(-6, 0,  2), new WorldPos(-2, 0, -6), new WorldPos(-2, 0,  6),
        new WorldPos( 2, 0, -6), new WorldPos( 2, 0,  6), new WorldPos( 6, 0, -2), new WorldPos( 6, 0,  2), new WorldPos(-5, 0, -4),
        new WorldPos(-5, 0,  4), new WorldPos(-4, 0, -5), new WorldPos(-4, 0,  5), new WorldPos( 4, 0, -5), new WorldPos( 4, 0,  5),
        new WorldPos( 5, 0, -4), new WorldPos( 5, 0,  4), new WorldPos(-6, 0, -3), new WorldPos(-6, 0,  3), new WorldPos(-3, 0, -6),
        new WorldPos(-3, 0,  6), new WorldPos( 3, 0, -6), new WorldPos( 3, 0,  6), new WorldPos( 6, 0, -3), new WorldPos( 6, 0,  3),
        new WorldPos(-7, 0,  0), new WorldPos( 0, 0, -7), new WorldPos( 0, 0,  7), new WorldPos( 7, 0,  0), new WorldPos(-7, 0, -1),
        new WorldPos(-7, 0,  1), new WorldPos(-5, 0, -5), new WorldPos(-5, 0,  5), new WorldPos(-1, 0, -7), new WorldPos(-1, 0,  7),
        new WorldPos( 1, 0, -7), new WorldPos( 1, 0,  7), new WorldPos( 5, 0, -5), new WorldPos( 5, 0,  5), new WorldPos( 7, 0, -1),
        new WorldPos( 7, 0,  1), new WorldPos(-6, 0, -4), new WorldPos(-6, 0,  4), new WorldPos(-4, 0, -6), new WorldPos(-4, 0,  6),
        new WorldPos( 4, 0, -6), new WorldPos( 4, 0,  6), new WorldPos( 6, 0, -4), new WorldPos( 6, 0,  4), new WorldPos(-7, 0, -2),
        new WorldPos(-7, 0,  2), new WorldPos(-2, 0, -7), new WorldPos(-2, 0,  7), new WorldPos( 2, 0, -7), new WorldPos( 2, 0,  7),
        new WorldPos( 7, 0, -2), new WorldPos( 7, 0,  2), new WorldPos(-7, 0, -3), new WorldPos(-7, 0,  3), new WorldPos(-3, 0, -7),
        new WorldPos(-3, 0,  7), new WorldPos( 3, 0, -7), new WorldPos( 3, 0,  7), new WorldPos( 7, 0, -3), new WorldPos( 7, 0,  3),
        new WorldPos(-6, 0, -5), new WorldPos(-6, 0,  5), new WorldPos(-5, 0, -6), new WorldPos(-5, 0,  6), new WorldPos( 5, 0, -6),
        new WorldPos( 5, 0,  6), new WorldPos( 6, 0, -5), new WorldPos( 6, 0,  5) 
    };

    void Update()
    {
		if (DeleteChunks())
		{
			return;
		}
        FindChunksToLoad();
        LoadAndRenderChunks();
    }

    void FindChunksToLoad()
    {
        WorldPos playerPos = new WorldPos(
            Mathf.FloorToInt(transform.position.x / Chunk.CHUNK_SIZE) * Chunk.CHUNK_SIZE,
            Mathf.FloorToInt(transform.position.y / Chunk.CHUNK_SIZE) * Chunk.CHUNK_SIZE,
            Mathf.FloorToInt(transform.position.z / Chunk.CHUNK_SIZE) * Chunk.CHUNK_SIZE
            );

        if (updateList.Count == 0)
        {
            for (int i = 0; i < chunkPositions.Length; i++)
            {
                WorldPos newChunkPos = new WorldPos(
                    chunkPositions[i].x * Chunk.CHUNK_SIZE + playerPos.x,
                    0,
                    chunkPositions[i].z * Chunk.CHUNK_SIZE + playerPos.z
                    );

                Chunk newChunk = world.GetChunk(
                    newChunkPos.x,
                    newChunkPos.y,
                    newChunkPos.z
                    );

                if (newChunk != null && (newChunk.rendered || updateList.Contains(newChunkPos)))
                {
                    continue;
                }

				for (int y = -4; y < 4; y++)
				{
					for (int x = newChunkPos.x - Chunk.CHUNK_SIZE; x <= newChunkPos.x + Chunk.CHUNK_SIZE; x += Chunk.CHUNK_SIZE)
					{
						for (int z = newChunkPos.z - Chunk.CHUNK_SIZE; z <= newChunkPos.z + Chunk.CHUNK_SIZE; z += Chunk.CHUNK_SIZE)
						{
							buildList.Add(new WorldPos(x, y * Chunk.CHUNK_SIZE, z));
						}
					}
					updateList.Add(new WorldPos(newChunkPos.x, y * Chunk.CHUNK_SIZE, newChunkPos.z));
				}
                return;
            }
        }
    }

    void LoadAndRenderChunks()
    {
		if (buildList.Count != 0)
        {
			for (int i = 0; i < buildList.Count && i < 8; i++)
            {
                BuildChunk(buildList[0]);
                buildList.RemoveAt(0);
            }
			return;
        }

		if (updateList.Count != 0)
        {
            Chunk chunk = world.GetChunk(updateList[0].x, updateList[0].y, updateList[0].z);
            if (chunk != null)
            {
                chunk.update = true;
            }
            updateList.RemoveAt(0);
        }
	}
	
	void BuildChunk(WorldPos pos)
	{
		if (world.GetChunk(pos.x, pos.y, pos.z) == null)
		{
			world.CreateChunk(pos.x, pos.y, pos.z);
		}
	}

	bool DeleteChunks()
	{
		if (timer == 10)
		{
			var chunksToDelete = new List<WorldPos>();
			foreach (var chunk in world.chunks)
			{
				float distance = Vector3.Distance(
					new Vector3(chunk.Value.pos.x, 0, chunk.Value.pos.z),
					new Vector3(transform.position.x, 0, transform.position.z)
					);

				if (distance > 256)
				{
					chunksToDelete.Add(chunk.Key);
				}
			}

			foreach (var chunk in chunksToDelete)
			{
				world.DestroyChunk(chunk.x, chunk.y, chunk.z);
			}

			timer = 0;
			return true;
		}

		timer++;
		return false;
	}
}
