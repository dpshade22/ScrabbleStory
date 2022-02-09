using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject tile;
    public int x, y = 0;

    private void Update()
    {
        if (tile != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = tile.GetComponent<SpriteRenderer>().sprite;
        }
    }

    void OnMouseDown()
    {

        if (tile != null)
        {
            Debug.Log("Node down");
            tile.GetComponent<Tile>().ReturnTile();
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Node");
        }
    }

    public GameObject GetNodeRight()
    {
        foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node"))
        {
            if (node.GetComponent<Node>().x == gameObject.GetComponent<Node>().x + 1 && node.GetComponent<Node>().y == gameObject.GetComponent<Node>().y)
                return node;
        }
        return gameObject;
    }
    public GameObject GetNodeUp()
    {
        foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node"))
        {
            if (node.GetComponent<Node>().x == gameObject.GetComponent<Node>().x && node.GetComponent<Node>().y == gameObject.GetComponent<Node>().y + 1)
                return node;
        }
        return gameObject;
    }
    public GameObject GetNodeLeft()
    {
        foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node"))
        {
            if (node.GetComponent<Node>().x == gameObject.GetComponent<Node>().x - 1 && node.GetComponent<Node>().y == gameObject.GetComponent<Node>().y)
                return node;
        }
        return gameObject;
    }
    public GameObject GetNodeDown()
    {
        foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node"))
        {
            if (node.GetComponent<Node>().x == gameObject.GetComponent<Node>().x + 1 && node.GetComponent<Node>().y == gameObject.GetComponent<Node>().y - 1)
                return node;
        }
        return gameObject;
    }
    public void TurnOffTile()
    {
        gameObject.SetActive(false);

    }
}
