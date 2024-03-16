using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviour
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
    

        if (other.TryGetComponent(out  PlayerSettings ps))
        {
            ps.TakeDamage(info.damage);
            PhotonNetwork.Destroy(gameObject);
        }
    }
    public void StartMove(Vector3 dir)
    {
        rb.velocity = dir * info.speed;
    }
}
