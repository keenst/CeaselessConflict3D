using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGeneration : MonoBehaviour
{
    private enum TileType
    {
        Empty = 0,
        Wall = 1,
        Player = 2,
        WallWithTorch = 3
    }
    
    public Tilemap tilemap;
    public RuleTile dungeonTile;
    public GameObject player;

    private readonly int[][] _map =
    {
        new[] { 3, 1, 1, 1 },
        new[] { 0, 1, 0, 1 },
        new[] { 0, 1, 0, 1 },
        new[] { 1, 1, 1, 1 },
        new[] { 1, 2, 1, 1 },
        new[] { 1, 1, 1, 1 },
    };

    public void Start()
    {
        Generate(_map);
        int childCount = tilemap.transform.childCount;
        for (int i = 0; i < childCount - 1; i++)
        {
            string name = tilemap.transform.GetChild(i).name;
            //Debug.Log(name);
        }
        
        TileBase tile = tilemap.GetTile(new Vector3Int(0, 0));
        TileData data = new();
        tile.GetTileData(new Vector3Int(0, 0), tilemap, ref data);
        //Debug.Log(data.gameObject.name);
    }

    private void Generate(IReadOnlyList<int[]> map)
    {
        for (int y = 0; y < map.Count; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                TileType type = (TileType)map[y][x];
                
                switch (type)
                {
                    case TileType.Empty:
                        continue;
                    case TileType.Wall:
                        SpawnTile(x, y, false);
                        break;
                    case TileType.Player:
                        SpawnTile(x, y, false);
                        
                        Vector3 tileLocation = tilemap.CellToWorld(new Vector3Int(x, y));
                        player.transform.position = tileLocation + new Vector3(0.5F, 0, 0.5F);
                        break;
                    case TileType.WallWithTorch:
                        SpawnTile(x, y, true);                        
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    private void SpawnTile(int x, int y, bool torch)
    {
        tilemap.SetTile(new Vector3Int(x, y), dungeonTile);

        //if (!torch) return;
        
        TileBase tile = tilemap.GetTile(new Vector3Int(x, y));
        TileData data = new();
        tile.GetTileData(new Vector3Int(x, y), tilemap, ref data);
        if (torch) data.gameObject.GetComponent<TorchSpawner>().PlaceTorch();
        //Debug.Log(data.gameObject.name);
    }
}
