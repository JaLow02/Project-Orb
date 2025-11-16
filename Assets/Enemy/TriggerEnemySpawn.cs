using System;
using UnityEngine;

public class TriggerEnemySpawn : MonoBehaviour
{
    public Action OnPlayerEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerEntered?.Invoke();
        }
    }
}
