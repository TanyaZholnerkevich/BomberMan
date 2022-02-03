using UnityEngine;
using System.Collections;

public class Bandit : MonoBehaviour {
    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
