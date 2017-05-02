using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnInvisible : MonoBehaviour {

    void OnBecameInvisible ()
    {
        Destroy(gameObject);
    }
}
