using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        float movDistance = Time.deltaTime * speed;
        transform.Translate(Vector3.forward * movDistance);
        Destroy(gameObject, 5.0f);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag != "Player" && tag != (other + "Projectile"))
            Destroy(gameObject);
    }
}