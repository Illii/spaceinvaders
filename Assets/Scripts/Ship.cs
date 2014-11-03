using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
	/// <summary>
	/// The bullet prefab.
	/// </summary>
	public Transform bulletPrefab;
	private Transform bullet;
	private GUIText livesLabel;
	private float timer = 0f;

	// Use this for initialization
	void Start ()
	{
		livesLabel = GameObject.Find("LivesLabel").guiText;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Left movement
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-16 * Time.deltaTime, 0, 0);
		}
		// Right movement
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(16 * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey(KeyCode.Space))
		{
			if (timer> 0.3f)
			{
				shoot();
				timer = 0f;
			}
		}

		timer += Time.deltaTime;
	}

	private void shoot()
	{
		bullet = Instantiate(bulletPrefab) as Transform;
		if (bullet !=null)
		{
			bullet.transform.position = new Vector3 (transform.position.x, transform.position.y, 0f);
			bullet.rigidbody2D.velocity = new Vector2 (0f, 15f);
		}

	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.collider.CompareTag("Invader"))
		{
			Destroy(collision.collider.gameObject);
			transform.position = new Vector3(0, transform.position.y, 0);
		}
	}
}
