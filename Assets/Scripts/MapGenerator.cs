using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Tilemap tilemap; // Reference to your Tilemap
    public Tile grassTile, emptyTile, rockTile, gravelTile, copperTile, tinTile, goldTile, sapphireTile, emeraldTile, rubyTile, diamondTile, opalTile, tungstonTile, platinumTile, unknownTile; // References to your Tiles
    public int width = 10;
    public int height = 10;
    private MaterialType[,] mapGrid;

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        mapGrid = new MaterialType[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (y == height - 1)
                {
                    mapGrid[x, y] = MaterialType.Grass; // Set top layer to Grass
                }
                else
                {
                    int rand = UnityEngine.Random.Range(0, 10); // Adjusted range for a 1 in 10 chance
                    if (rand < 7) // 70% chance to be Empty
                    {
                        mapGrid[x, y] = MaterialType.Empty;
                    }
                    else
                    {
                        // Adjust the range based on the number of materials excluding Grass and Empty
                        //mapGrid[x, y] = (MaterialType)UnityEngine.Random.Range(1, Enum.GetNames(typeof(MaterialType)).Length - 1);
                        mapGrid[x, y] = GetMaterialBasedOnDepth(y);
                    }
                }
                PlaceTile(x, y, mapGrid[x, y]);
            }
        }
    }
    void PlaceTile(int x, int y, MaterialType type)
    {
        Vector3Int position = new Vector3Int(x, y, 0);
        switch (type)
        {
            case MaterialType.Grass:
                tilemap.SetTile(position, grassTile);
                break;
            case MaterialType.Empty:
                tilemap.SetTile(position, emptyTile);
                break;
            case MaterialType.Tin:
                tilemap.SetTile(position, tinTile);
                break;
            case MaterialType.Copper:
                tilemap.SetTile(position, copperTile);
                break;
            case MaterialType.Gold:
                tilemap.SetTile(position, goldTile);
                break;
            case MaterialType.Diamond:
                tilemap.SetTile(position, diamondTile);
                break;
            case MaterialType.Platinum:
                tilemap.SetTile(position, platinumTile);
                break;
            case MaterialType.Unknown:
                tilemap.SetTile(position, unknownTile);
                break;
            case MaterialType.Sapphire:
                tilemap.SetTile(position, sapphireTile);
                break;
            case MaterialType.Emerald:
                tilemap.SetTile(position, emeraldTile);
                break;
            case MaterialType.Ruby:
                tilemap.SetTile(position, rubyTile);
                break;
            case MaterialType.Tungston:
                tilemap.SetTile(position, tungstonTile);
                break;
            case MaterialType.Rock:
                tilemap.SetTile(position, rockTile);
                break;
            case MaterialType.Gravel:
                tilemap.SetTile(position, gravelTile);
                break;
            default:
                break;
        }
    }
    MaterialType GetRandomMaterialType()
    {
        float rand = UnityEngine.Random.Range(0f, 1f); // Random value between 0 and 1
        if (rand < 0.7f) return MaterialType.Empty; // 70% chance
        if (rand < 0.8f) return MaterialType.Tin; // 10% chance
        if (rand < 0.9f) return MaterialType.Copper; // 10% chance
                                                   // Adjust probabilities as needed
        return MaterialType.Diamond; // 10% chance
    }
    MaterialType GetMaterialBasedOnDepth(int depth)
    {
        float depthFactor = (float)depth / height;

        if (depthFactor < 0.1f)
            return (MaterialType)UnityEngine.Random.Range(1, Enum.GetNames(typeof(MaterialType)).Length - 1);
        else if (depthFactor < 0.2f)
            return (MaterialType)UnityEngine.Random.Range(1, 11);
        else if (depthFactor < 0.5f)
            return (MaterialType)UnityEngine.Random.Range(1, 9);
        else if (depthFactor < 0.7)
            return (MaterialType)UnityEngine.Random.Range(1, 6);
        else if(depthFactor < 0.9)
            return (MaterialType)UnityEngine.Random.Range(1, 5);
        else
            return MaterialType.Empty;
    }

}
public enum MaterialType { Grass, Empty, Tin, Copper, Rock, Gravel, Gold, Sapphire, Emerald, Ruby, Diamond, Tungston, Platinum, Unknown }
