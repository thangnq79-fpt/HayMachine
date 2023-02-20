using UnityEngine;
using System.Collections;

public class TweenScale : MonoBehaviour
{
    public float targetScale;
    public float timeToReachTarget = 2f;

    private float startScale;
    private float percentScaled;

    // Use this for initialization
    private void Start()
    {
        startScale = transform.localScale.x;
    }

    // Update is called once per frame
    private void Update()
    {
        if (percentScaled < 1f)
        {
            percentScaled += Time.deltaTime / timeToReachTarget;
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}