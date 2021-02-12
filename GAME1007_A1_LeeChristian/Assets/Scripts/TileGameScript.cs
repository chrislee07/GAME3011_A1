using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGameScript : MonoBehaviour
{
    private System.Random rand = new System.Random();
    [SerializeField]
    public GameObject[] tiles;
    public GameObject[] shuffled = new GameObject[399];
    public GameObject[,] grid = new GameObject[20, 20];
    public bool gameOn = false;
    public int Score;
    public int numClicks = 3;
    public GameObject counter;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Shuffle();
        SetValues();
    }

    void ResetGame()
    {
        for (int r = 0; r<20; r++)
        {
            for (int c = 0; c<20; c++)
            {
                grid[r, c] = tiles[(r * 20) + c];
                grid[r, c].GetComponent<TileScript>().SetGridIndices(r, c);
                //grid[r, c].GetComponent<TileScript>().SetValue(100);
                //grid[r, c].GetComponent<RectTransform>().localPosition = new Vector3((c - 1) * 10, (r - 1) * 10, 0);
            }

        }
        gameOn = false;

    }

    void OnEnable()
    {
        ResetGame();
    }

    public void Shuffle()
    {
        for (int v = 0; v < 10; v++)
        {
            int r = rand.Next(1, 19);
            int c = rand.Next(1, 19);
            Debug.Log("Row : " + r + " Col: " + c);
            grid[r, c].GetComponent<TileScript>().SetGridIndices(r, c);
            grid[r, c].GetComponent<TileScript>().SetValue(100);
        }
        gameOn = true;

    }

    public void SetValues()
    {
        for (int r = 0; r < 20; r++)
        {
            for (int c = 0; c < 20; c++)
            {
                int x = grid[r, c].GetComponent<TileScript>().value;
                if (x == 100)
                {
                    grid[r, c - 1].GetComponent<TileScript>().SetValue(50);
                    grid[r - 1, c - 1].GetComponent<TileScript>().SetValue(50);
                    grid[r - 1, c].GetComponent<TileScript>().SetValue(50);
                    grid[r - 1, c + 1].GetComponent<TileScript>().SetValue(50);
                    grid[r, c + 1].GetComponent<TileScript>().SetValue(50);
                    grid[r + 1, c + 1].GetComponent<TileScript>().SetValue(50);
                    grid[r + 1, c].GetComponent<TileScript>().SetValue(50);
                    grid[r + 1, c - 1].GetComponent<TileScript>().SetValue(50);
                }
                else if (x <50)
                    grid[r, c].GetComponent<TileScript>().SetValue(25);
            }
        }
    }


}
