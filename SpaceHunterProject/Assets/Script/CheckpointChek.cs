using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointChek : MonoBehaviour
{

    // checkpoint par defaut si cocher
    public bool isDefault;

    private void Start()
    {
        if (isDefault)
        {
            CheckpointManager.SetActivCheckpoint(this);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        CheckpointManager.SetActivCheckpoint(this);
    }
}
