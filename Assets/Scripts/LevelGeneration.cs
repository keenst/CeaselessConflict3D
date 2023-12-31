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
        Player = 2
    }
    
    public Tilemap tilemap;
    public RuleTile dungeonTile;
    public GameObject player;

    private readonly int[][] _map =
    {
        new[] { 0, 1, 1, 1 },
        new[] { 0, 1, 0, 1 },
        new[] { 0, 1, 0, 1 },
        new[] { 1, 1, 1, 1 },
        new[] { 1, 2, 1, 1 },
        new[] { 1, 1, 1, 1 },
    };

    private PlayerMovement _playerMovement;

    public void Start()
    {
        _playerMovement = player.GetComponent<PlayerMovement>();
        Generate(_map);
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
                        tilemap.SetTile(new Vector3Int(x, y), dungeonTile);
                        break;
                    case TileType.Player:
                        tilemap.SetTile(new Vector3Int(x, y), dungeonTile);
                        
                        Vector3 tileLocation = tilemap.CellToWorld(new Vector3Int(x, y));
                        player.transform.position = tileLocation + new Vector3(0.5F, 0, 0.5F);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
