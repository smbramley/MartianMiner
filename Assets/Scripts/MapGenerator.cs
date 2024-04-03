using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Tilemap tilemap; // Reference to your Tilemap
    public Tile emptyTile, coalTile, goldTile, diamondTile; // References to your Tiles
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
                mapGrid[x, y] = (MaterialType)Random.Range(0, 4); // Assuming 4 material types
                PlaceTile(x, y, mapGrid[x, y]);
            }
        }
    }

    void PlaceTile(int x, int y, MaterialType type)
    {
        Vector3Int position = new Vector3Int(x, y, 0);
        switch (type)
        {
            case MaterialType.Empty:
                tilemap.SetTile(position, emptyTile);
                break;
            case MaterialType.Coal:
                tilemap.SetTile(position, coalTile);
                break;
            case MaterialType.Gold:
                tilemap.SetTile(position, goldTile);
                break;
            case MaterialType.Diamond:
                tilemap.SetTile(position, diamondTile);
                break;
            default:
                break;
        }
    }
}
public enum MaterialType { Empty, Tin, Copper, Coal, Gold, Diamond, Ruby, Emerald, Saphire }
