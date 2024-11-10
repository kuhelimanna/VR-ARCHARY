using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StickingArrowToSurface : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private SphereCollider myCollider;

    [SerializeField]
    private GameObject stickingArrow;

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        myCollider.isTrigger = true;

        GameObject arrow = Instantiate(stickingArrow);
        arrow.transform.position = transform.position;
        arrow.transform.forward = transform.forward;

        if (collision.collider.attachedRigidbody != null)
        {
            arrow.transform.parent = collision.collider.attachedRigidbody.transform;
        }

        collision.collider.GetComponent<IHittable>()?.GetHit();
        // Attach the arrow to the colliding target
        Transform collidingObjectTransform = collision.transform;
        transform.SetParent(collidingObjectTransform);

        // Optionally reset local position and rotation to match the colliding object
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        // Stop the arrow from moving
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true; // Makes the Rigidbody kinematic to stop all movement
        }
        // Destroy(gameObject);

    }
}