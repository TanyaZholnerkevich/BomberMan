using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    
    private bool isMovement;

    private void Update()
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
            Instantiate(bomb, transform.position, Quaternion.identity);
        }

        //StartCoroutine(Restart());
    }

    private void MovePlayerTo(Vector2 dir)
    {
        if (Raycast(dir))
        {
            return;
        }

        isMovement = true;

        var pos = (Vector2)transform.position + dir;
        transform.DOMove(pos, 0.2f).OnComplete(() =>
        {
            isMovement = false;
        }).SetEase(Ease.Linear);
    }

    private bool Raycast(Vector2 dir)
    {
        var hit = Physics2D.Raycast(transform.position, dir, 1f);
        return hit.collider != null;
    }

    /*private IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime(3f);
        var distance = Vector2.Distance(transform.position, bomb.transform.position);
        if (distance < 0.5f)
        {
            SceneManager.LoadScene(0);
            Debug.Log("YOU LOOSER");
        }
    }*/
}
