using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlatform : MonoBehaviour
{
    [SerializeField] float time = 0.5f;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitBeforeDestroy(time));
        }
    }

    private IEnumerator WaitBeforeDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
