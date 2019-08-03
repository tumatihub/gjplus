using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FieldController : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] Tile amarelo;
    [SerializeField] Tile verde;

    Grid grid;

    Tilemap tilemap1;
    Tilemap tilemap2;

    int maxFieldX = 10;
    int maxFieldY = 10;

    int beat = 0;

    void Start()
    {
        NextBeatField();

    }

    public void NextBeatField()
    {
        beat = (beat + 1) % 2;
        for (int x = 0; x < maxFieldX; x++)
        {
            for (int y = 0; y < maxFieldY; y++)
            {
                if ((x + y) % 2 == beat)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), amarelo);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), verde);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
