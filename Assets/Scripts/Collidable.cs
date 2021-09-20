using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class Collidable : MonoBehaviour
	{
		public ContactFilter2D filter;
		private Collider2D boxCollider;
		private Collider2D[] hits = new Collider2D[10];
		private void Awake()
		{

		}


		// Start is called before the first frame update
		protected virtual void Start()
		{
			boxCollider = GetComponent<Collider2D>();
		}

		protected virtual void Update()
		{
			//Collision work
			boxCollider.OverlapCollider(filter, hits);

			for (int i = 0; i < hits.Length; i++)
			{
				if (hits[i] == null)
					continue;

				OnCollide(hits[i]);

				//The array is not cleaned up
				hits[i] = null;

			}

		}

		protected virtual void OnCollide(Collider2D coll)
		{
			Debug.Log("Oncollide was not implemented in " + this.name);
		}

	}
}
