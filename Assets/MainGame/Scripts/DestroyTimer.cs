using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour
{
    public float timeToDestroy;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
