using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutBullet : MonoBehaviour
{
    [SerializeField] private BulletInfo info;
    private Rigidbody rb;

    void Start()
    {

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        info.render = gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.TryGetComponent(out PlayerSettings ps))
        {
            ps.TakeDamage(info.damage);

        }
    }
    public void StartMove(Vector3 dir)
    {
        rb.velocity = dir * info.speed;
    }
}
