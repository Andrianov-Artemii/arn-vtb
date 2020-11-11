using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Search
{
	[System.Serializable]
	public class SearchSer
	{
		public string name;
		public string info;
		public Vector3 pos;

		public int sortingOrder;

		public SearchSer(SearchSer searchSer)
		{
			this.name = searchSer.name;
			this.info = searchSer.info;
			this.pos = searchSer.pos;
			this.sortingOrder = searchSer.sortingOrder;
		}

		public SearchSer(string name, string info, Vector3 pos, int sortingOrder)
		{
			this.name = name;
			this.info = info;
			this.pos = pos;
			this.sortingOrder = sortingOrder;
		}

		// override object.Equals
		public override bool Equals(object obj)
		{

			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			SearchSer s = (SearchSer) obj;
			return (name == s.name) && (info == s.info) && (pos.Equals(pos)) && (sortingOrder == s.sortingOrder);
		}
	}

	[System.Serializable]
	public class Vector3S
	{
		public float x;
		public float y;
		public float z;

		public Vector3S(Vector3 vector3)
		{
			x = vector3.x;
			y = vector3.y;
			z = vector3.z;
		}

		public Vector3S(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public Vector3 ToVector3()
		{
			return new Vector3(x, y, z);
		}
	}
}
