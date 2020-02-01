using System.Collections;
using UnityEngine;

namespace Visuals
{
    public class CameraShake : MonoBehaviour
    {
        public IEnumerator Shake(float duration, float magnitude)
        {
            var originalPosition = transform.localPosition;
            float elapsed = 0;

            while (elapsed < duration)
            {
                var x = Random.Range(-1f, 1f) * magnitude;
                var y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(x, y, originalPosition.z);
                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = originalPosition;
        }
    }
}