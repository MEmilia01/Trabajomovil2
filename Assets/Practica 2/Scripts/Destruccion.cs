using UnityEngine;

public class Destruccion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("destruccion" +  other.gameObject.name);
        }
    }
}
