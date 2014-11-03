using UnityEngine;
using System.Collections;

public class InvadersManager : MonoBehaviour
{
	public Transform invader1Prefab;
	public Transform invader2Prefab;
	public Transform invader3Prefab;
	public Transform invader;
	public Transform[] invaderTab;
	public float vitesse = 0.1f;
	private bool goingRight = true;

	// Use this for initialization
	void Start ()
	{
		invaderTab = new Transform[55];
		int cpt = 0;
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 11; j++)
			{
				if (i == 0)
				{
				invader = Instantiate(invader3Prefab) as Transform;
				}
				if (i >0 && i<3)
				{
					invader = Instantiate(invader2Prefab) as Transform;
				}
				if (i >= 3)
				{
					invader = Instantiate(invader1Prefab) as Transform;
				}
				invader.transform.position = new Vector3((j*3f - 5f*3f), (i*3f - 2f*3f), 0f);
				invader.parent = transform;
				invaderTab[cpt] = invader;
				cpt++;
			} 
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		for (int i = 0; i < 55; i++) 
		{
			if (invaderTab[i] != null)
			{
				if (goingRight == true)
				{
					invaderTab[i].transform.Translate (new Vector3 (vitesse, 0f, 0f));
				}
				else 
				{
					invaderTab[i].transform.Translate (new Vector3 (-vitesse, 0f, 0f));
				}
			}		
		}
	}

	public void moveInvadersCloser ()
	{
		goingRight = !goingRight;
		vitesse += 0.085f;
		for (int i=0; i <55; i++)
			{
				if (invaderTab [i] != null) 
					{
					invaderTab [i].transform.Translate (new Vector3 (0f, -1f, 0f));
					}
			}
	}
	public void destroyInvader (Transform invader)
	{
		for (int i = 0; i < 55; i++) 
		{
			if (invaderTab[i] == invader)
			{
				Destroy (invader.gameObject);
				Destroy (invaderTab[i].gameObject);

			}		
		}
	}
}
