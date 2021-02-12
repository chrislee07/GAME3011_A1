using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour, IPointerClickHandler
{

    public int row, col;
    public int value;
    public int clicks;
    private TileGameScript tgs;
    public GameObject counter;


    void Start()
    {
        tgs = GameObject.Find("MiniGame").GetComponent<TileGameScript>();

    }

    public void SetGridIndices(int r, int c)
    {
        row = r;
        col = c;
    }

    public void SetValue(int v)
    {
        value = v;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        Debug.Log(eventData);
        if (value > 0)
        {
            string x;
            x = counter.GetComponent<UnityEngine.UI.Text>().text;
            int temp = int.Parse(x);
            temp = temp + value;
            counter.GetComponent<UnityEngine.UI.Text>().text = temp.ToString();
            value = 0;
        }


    }

}
