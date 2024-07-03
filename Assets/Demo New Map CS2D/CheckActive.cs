using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckActive : MonoBehaviour
{
    public GameObject[] targetObject;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            foreach (GameObject obj in targetObject)
            {
                if (targetObject != null)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
}
