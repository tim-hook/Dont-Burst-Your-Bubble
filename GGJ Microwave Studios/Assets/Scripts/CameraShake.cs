using System.Collections;
using Unity.Burst;
using UnityEngine;

[BurstCompile]
public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orginalPositon = transform.position;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1.0f, 1.0f) * magnitude;
            float y = Random.Range(-1.0f, 1.0f) * magnitude;

            transform.localPosition = new Vector3(x, y,orginalPositon.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = orginalPositon;

    }
}
