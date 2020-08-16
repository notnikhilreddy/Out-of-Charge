using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float shootTime = 2f;
	public GameObject bulletObject;
	public float bulletSpeed = 10f;

	private Vector3 shootPoint;

    // Start is called before the first frame update
    void Start()
    {
        // IEnumerator coroutine = Shoot();
        InvokeRepeating("Shoot", 1f, shootTime);
        shootPoint = transform.GetChild(0).position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot() {
    	GameObject newBullet = Instantiate(bulletObject, shootPoint, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x*bulletSpeed, 0f);
        // yield return null;
    }
}
