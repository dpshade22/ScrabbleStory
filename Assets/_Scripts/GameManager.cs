using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _height = 11;
    [SerializeField] private int _width = 11;
    [SerializeField] private Node _nodePrefab;


    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var Node = Instantiate(_nodePrefab, new Vector2(x, y), Quaternion.identity);
                Node.name = "Node " + x + " " + y;

                Node.y = y + 1;
                Node.x = x + 1;

                // if (Node.x == 5 && Node.y != 5)
                // {
                //     Node.TurnOffTile();
                // }
            }
        }

    }

    public void OnMouseDown()
    {
        Debug.Log("I am working");
    }
}
