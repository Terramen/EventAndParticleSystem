using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DG.Tweening;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class BanditController : MonoBehaviour
{
    private bool isMovement;
    private bool cantPlantBomb;

    public bool CantPlantBomb
    {
        set => cantPlantBomb = value;
    }
    [SerializeField] private LayerMask raycastMask;
    [SerializeField] private GameObject bombPrefab;

    
    void Update()
    {
        if (isMovement)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayerTo(Vector2.left);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayerTo(Vector2.right);
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovePlayerTo(Vector2.up);
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePlayerTo(Vector2.down);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(1);
            if (!cantPlantBomb)
            {
                cantPlantBomb = true;
                Instantiate(bombPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    private void MovePlayerTo(Vector2 direction)
    {
        if (Raycast(direction))
        {
            return;
        }

        isMovement = true;

        var pos = (Vector2) transform.position + direction;

        transform.DOMove(pos, 0.5f).OnComplete(() =>
        {
            isMovement = false;
        });
    }
    

    private bool Raycast(Vector2 direction)
    {
        var hit = Physics2D.Raycast(transform.position, direction, 1f, raycastMask);
        return hit.collider != null;
    }
    

}
