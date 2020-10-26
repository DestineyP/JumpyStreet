using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(DestroySelf());
    }

    private void Update() //Movement for the log.
    {
        if (transform.rotation == new Quaternion(90f, 0f, 0f, 0f))
        {
            transform.Translate(new Vector3(0, -Time.deltaTime * 3.5f, 0));
        }
        if (transform.rotation == new Quaternion(-90f, 0f, 0f, 0f))
        {
            transform.Translate(new Vector3(0, -Time.deltaTime * 3.5f, 0));
        }

    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(25f);

        Destroy(gameObject);
    }
}
