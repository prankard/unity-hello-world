using System;
using Robotlegs.Bender.Framework.API;
using UnityEngine;

namespace helloworldmulticontextdifferentroots
{
	[System.Serializable]
	public abstract class ContextHolder : MonoBehaviour
	{
		public IContext Context { get; protected set; }

		public abstract void Initialize ();
	}
}

