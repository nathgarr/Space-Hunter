using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    [SerializeField]
    GameObject slimeBallPrefab;
    public Transform targetObject;

    public float viewRaduis = 10;
    public float viewAngles = 360;
    public float slimeBallSpeed = 4;

    public float fireRate = 1f;
    private float nextFire = 0.0f;

    public LayerMask playerMask;

    public bool m_PlayerInRAnge;

    Vector3 PlayerLastPosition = Vector3.zero;
    Vector3 m_PlayerPosition;

    Coroutine monsterCorout;
   
    void Start()
    {
        m_PlayerInRAnge = false;
    }
    public void OnDrawGizmosSelected()
    {
        Handles.color = m_PlayerInRAnge ? Color.red : Color.green;
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, viewAngles, viewRaduis);

    }

    // Update is called once per frame
    void Update()
    {
        SlimeView();
    }

    public void SlimeView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRaduis, playerMask);
        for (int i = 0; i < playerInRange.Length; i++)
        {
            if (playerInRange.Length > 0)
            {
                m_PlayerInRAnge = true;
                if (monsterCorout == null)
                {
                    monsterCorout = StartCoroutine(FireCorout());
                }

            }
            else
            {
                m_PlayerInRAnge = false;
            }
        }
    }
    IEnumerator FireCorout()
    {
        while (m_PlayerInRAnge)
        {
            float fireDelay = Random.Range(1f, 2f);
            yield return new WaitForSeconds(fireDelay);
            GameObject projectilInstance = Instantiate(slimeBallPrefab);

            projectilInstance.transform.position = transform.position;
        }
        monsterCorout = null;
    }

}
