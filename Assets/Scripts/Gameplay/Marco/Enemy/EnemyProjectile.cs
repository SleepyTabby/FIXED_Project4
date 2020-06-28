using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;
    [SerializeField] private float MaxDistance;
    private Vector3 target;
    private Transform firingPoint;
    private float countdown;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
        firingPoint = transform;
    }

    
    void Update()
    {
        //

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        countdown++;
        if (countdown >= 500)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
