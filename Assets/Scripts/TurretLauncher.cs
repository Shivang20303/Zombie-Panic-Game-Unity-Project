using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLauncher : MonoBehaviour
{
    public GameObject spawn;
    public float kickDistance = 300.0f;
    private bool spawned;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && spawned == false)
        {
            spawned = true;

            // This prevents the turret base being rotated in x or y
            Vector3 forward = transform.forward;
            forward.y = 0f;
            Quaternion rotation = Quaternion.LookRotation(forward.normalized, Vector3.up);

            var clone = Instantiate(spawn, gameObject.transform.position, rotation);
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * kickDistance);
        }
    }
}