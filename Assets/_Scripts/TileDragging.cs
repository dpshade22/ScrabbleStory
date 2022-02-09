using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDragging : MonoBehaviour
{
    private bool _dragging;
    private Vector2 _offset, _originalPosition;
    private Node _node;

    private void Awake()
    {
        _originalPosition = transform.position;
    }

    void Update()
    {
        if (!_dragging) return;

        var mousePosition = GetMousePosition();

        transform.position = mousePosition - _offset;
    }

    void OnMouseDown()
    {
        _dragging = true;
        _offset = GetMousePosition() - (Vector2)transform.position;

    }

    void OnMouseUp()
    {
        PlaceTile();
        transform.position = _originalPosition;
        _dragging = false;
    }

    Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    GameObject FindNearestNode()
    {
        float _min = 2f;
        GameObject closestNode = null;

        foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node"))
        {
            if (Vector2.Distance(transform.position, node.transform.position) < _min)
            {
                if (node.GetComponent<Node>().tile == null)
                {
                    _min = Vector2.Distance(transform.position, node.transform.position);
                    closestNode = node;
                }
                else
                {
                    closestNode = null;
                }
            }
        }

        return closestNode;
    }

    void PlaceTile()
    {
        GameObject _node = FindNearestNode();

        if (_node == null)
            return;

        _node.GetComponent<Node>().tile = gameObject;
        gameObject.SetActive(false);
    }

    // public void ReturnTile(GameObject tile)
    // {
    //     gameObject.GetComponent<Node>().tile = null;
    //     tile.SetActive(true);
    // }
}
