using UnityEngine;

public class ArrowCollisionHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody arrowRb;
    [SerializeField]
    private SphereCollider myCollider;

    void Start()
    {
        // Get the Rigidbody component attached to the arrow
        arrowRb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        arrowRb.isKinematic = true;
        myCollider.isTrigger = true;

        //GameObject arrow = Instantiate(stickingArrow);
        //arrow.transform.position = transform.position;
       // arrow.transform.forward = transform.forward;

        if (collision.collider.attachedRigidbody != null)
        {
            //arrow.transform.parent = collision.collider.attachedRigidbody.transform;
            arrowRb.velocity = Vector3.zero;
            arrowRb.angularVelocity = Vector3.zero;
            //arrowRb.isKinematic = true;
        }

        collision.collider.GetComponent<IHittable>()?.GetHit();

        Destroy(gameObject);

    }
   /* private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Target" tag
        if (other.CompareTag("Target"))
        {
            Debug.Log("Arrow hit a target!");

            // Attach the arrow to the colliding target
            Transform collidingObjectTransform = other.transform;
            transform.SetParent(collidingObjectTransform);

            // Optionally reset local position and rotation to match the colliding object
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            // Stop the arrow from moving
            if (arrowRb != null)
            {
                arrowRb.velocity = Vector3.zero;
                arrowRb.angularVelocity = Vector3.zero;
                arrowRb.isKinematic = true; // Makes the Rigidbody kinematic to stop all movement
            }
        }
    }*/
}
