using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Target"))
        {
            print("Hit " + col.gameObject.name + "!");
            Destroy(gameObject);

        }
    }
}
