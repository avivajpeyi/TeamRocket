using UnityEngine;

// Forces the sprite to not rotate
namespace Visuals.DeformOnMovement
{
	public class ForceRotationIdentity : MonoBehaviour
	{
		private void Update ()
		{
			transform.rotation = Quaternion.identity;
		}
	}
}