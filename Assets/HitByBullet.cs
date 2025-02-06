using UnityEngine;
using System.Collections;

public class HitByBullet : MonoBehaviour
{
    [SerializeField] private UnityEngine.Rendering.Volume volume;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit:");
            StartCoroutine(ExampleCoroutine());

        }

    }
    
    IEnumerator ExampleCoroutine()
    {
            volume.weight = 1;
            yield return new WaitForSeconds(0.15f);
            volume.weight = 0;
    }

}
