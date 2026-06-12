using UnityEngine;
using UnityEngine.Tilemaps;

public class InfiniteMap : MonoBehaviour
{
    public Sprite[] mapTiles;
    public float chanceOfSpawn = 1.0f;
    public int horizontalTiles = 36;
    public int verticalTiles = 20;
    private Transform playerTransform;
    private int firstTileHor;
    private int firstTileVer;
    private int lastTileHor;
    private int lastTileVer;
    private Tilemap tilemap;

    private void Start()
    {
        firstTileHor = - horizontalTiles / 2;
        firstTileVer = - verticalTiles / 2;
        lastTileHor = horizontalTiles / 2;
        lastTileVer = verticalTiles / 2;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        tilemap = GetComponent<Tilemap>();
        for (int i = firstTileVer; i <= lastTileVer; i++)
        {
            for (int j = firstTileHor; j <= lastTileHor; j++)
            {
                tilemap.SetTile(new Vector3Int(j, i, 0), CreateTile());
            }
        }
    }

    private void Update()
    {
        float playerTileX = playerTransform.position.x;
        float playerTileY = playerTransform.position.y;
        playerTileX = playerTileX < 0 ? (int)playerTileX - 1 : (int)playerTileX;
        playerTileY = playerTileY < 0 ? (int)playerTileY - 1 : (int)playerTileY;
        if (playerTileX - horizontalTiles / 2 < firstTileHor)
        {
            firstTileHor--;
            for (int i = firstTileVer; i <= lastTileVer; i++)
            {
                tilemap.SetTile(new Vector3Int(firstTileHor, i), CreateTile());
                tilemap.SetTile(new Vector3Int(lastTileHor, i), null);
            }
            lastTileHor--;
        }
        else if (playerTileX + horizontalTiles / 2 > lastTileHor)
        {
            lastTileHor++;
            for (int i = firstTileVer; i <= lastTileVer; i++)
            {
                tilemap.SetTile(new Vector3Int(lastTileHor, i), CreateTile());
                tilemap.SetTile(new Vector3Int(firstTileHor, i), null);
            }
            firstTileHor++;
        }
        if (playerTileY - verticalTiles / 2 < firstTileVer)
        {
            firstTileVer--;
            for (int i = firstTileHor; i <= lastTileHor; i++)
            {
                tilemap.SetTile(new Vector3Int(i, firstTileVer), CreateTile());
                tilemap.SetTile(new Vector3Int(i, lastTileVer), null);
            }
            lastTileVer--;
        }
        else if (playerTileY + verticalTiles / 2 > lastTileVer)
        {
            lastTileVer++;
            for (int i = firstTileHor; i <= lastTileHor; i++)
            {
                tilemap.SetTile(new Vector3Int(i, lastTileVer), CreateTile());
                tilemap.SetTile(new Vector3Int(i, firstTileVer), null);
            }
            firstTileVer++;
        }
    }

    private Tile CreateTile()
    {
        if (Random.value > chanceOfSpawn)
        {
            return null;
        }
        Tile tile = ScriptableObject.CreateInstance<Tile>();
        tile.sprite = mapTiles[Random.Range(0, mapTiles.Length)];
        return tile;
    }
}
