using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] private float radius = 0.5f;
    [SerializeField] private LayerMask bombMask;
    [SerializeField] private GameObject explosion;

    private void Update()
    {
        StartCoroutine(Explosion());
    }

    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(explosion, transform.position, Quaternion.identity);
        var colliders = Physics2D.OverlapCircleAll(transform.position, radius, bombMask);
        foreach (var cldr in colliders)
        {
            Destroy(cldr.gameObject);
            if (cldr.CompareTag("Player"))
            {
                SceneManager.LoadScene(0);
                Debug.Log("YOU LOOSER");
            }
        }
        Destroy(this.gameObject);
    }
}
