using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CheckpointManager : MonoBehaviour
{
  public static CheckpointManager instance;
    public CheckpointChek activeCheckpoint;
    public void Awake()
    {
        instance = this;
    }

    public static void SetActivCheckpoint(CheckpointChek newActiveCheckpoint)
    {
        instance.activeCheckpoint = newActiveCheckpoint;
    }

    public static void RespawnFromLastCheckpoint(GameObject playerGo)
    {
        playerGo.transform.position = instance.activeCheckpoint.transform.position;
    }
}
