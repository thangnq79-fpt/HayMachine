using UnityEngine;
using System.Collections;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float gotHayDestroyDelay;
    public float heartOffset;
    public float dropDestroyDelay;

    public GameObject heartPrefab;

    private Collider myCollider;
    private Rigidbody myRigidbody;
    private bool hitByHay;
    private SheepSpawner sheepSpawner;

    private void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hay") && !hitByHay)
        {
            Destroy(other.gameObject);
            HitByHay();
        }
        else if (other.CompareTag("DropSheep"))
        {
            Drop();
        }
    }

    private void Drop()
    {
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        GameStateManager.Instance.DroppedSheep();
        Destroy(gameObject, dropDestroyDelay);
        sheepSpawner.RemoveSheepFromList(gameObject);
        SoundManager.Instance.PlaySheepDroppedClip();
    }

    private void HitByHay()
    {
        hitByHay = true;
        runSpeed = 0;

        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);

        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();
        tweenScale.targetScale = 0;
        tweenScale.timeToReachTarget = gotHayDestroyDelay;

        GameStateManager.Instance.SavedSheep();
        Destroy(gameObject, gotHayDestroyDelay);
        sheepSpawner.RemoveSheepFromList(gameObject);

        SoundManager.Instance.PlaySheepHitClip();
    }
}