using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    public static Killzone Instance;
    public LayerMask playerMask;


    private void Awake()
    {
        Instance = this;
    }
    public void OnTriggerEnter(Collider other)
    {
        CheckpointManager.RespawnFromLastCheckpoint(other.transform.root.gameObject);
        Debug.Log(other);
    }
}
