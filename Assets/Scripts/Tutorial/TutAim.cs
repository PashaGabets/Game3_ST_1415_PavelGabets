using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutAim : MonoBehaviour
{
    [SerializeField] private Transform spawnPostion;
    [SerializeField] private List<GameObject> allTragets;
    [SerializeField] private GameObject targetCylinder;
    [SerializeField] private float range;

    private PlayerInput inputs;
    private CharacterController controller;
    private GameObject targetObj;
    private bool canSearch = true;
    private int targetCount;
    public GameObject Bullet;

    private void Awake()
    {
        inputs = new PlayerInput();
        controller = GetComponent<CharacterController>();
 
    }

    private void Start()
    {

        targetCylinder.SetActive(false);
        inputs.CharacterControls.ChangeTarget.started += SelectNewTarget;
        inputs.CharacterControls.Attack.started += OnFire;
    }
    private void OnEnable()
    {
        inputs.CharacterControls.Enable();
    }
    private void OnDisable()
    {
        inputs.CharacterControls.Disable();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void SetTargetStatus(bool isTarget)
    {
        targetCylinder.SetActive(isTarget);
    }

    private void SelectTarget()
    {
        if (controller.velocity == Vector3.zero)
        {
            if (canSearch)
                InvokeRepeating("Calculate", 0f, 0.5f);
        }
        else
        {
            try
            {
                targetObj?.GetComponent<Aim>().SetTargetStatus(false);
            }
            catch (System.Exception)
            {


            }

            canSearch = true;
            CancelInvoke();
        }
    }

    private void Calculate()
    {
        canSearch = false;
        allTragets.Clear();

        RaycastHit[] hist = Physics.SphereCastAll(transform.position, range, transform.position, range);
        foreach (RaycastHit hit in hist)
        {
            GameObject tempObj = hit.collider.gameObject;
            if (tempObj.GetComponent<CharacterController>())
            {
                allTragets.Add(tempObj);
            }
            else continue;
        }
        SelectNewTarget();
    }
    private void SelectNewTarget()
    {
        foreach (GameObject obj in allTragets)
        {
            obj.GetComponent<TutAim>().SetTargetStatus(false);
        }
        if (targetCount >= allTragets.Count)
        {
            targetCount = 0;
        }

        if (allTragets.Count == 0)
        {
            return;
        }

        targetObj = allTragets[targetCount];
        targetObj.GetComponent<Aim>().SetTargetStatus(true);
    }
    private void SelectNewTarget(InputAction.CallbackContext context)
    {
        targetCount++;
        SelectNewTarget();
        
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        if (targetObj != null)
        {
            Vector3 dir = (targetObj.transform.position - transform.position).normalized;

            GameObject temp = Instantiate (Bullet,
            spawnPostion.position, Quaternion.identity);

            temp.GetComponent<Bullet>().StartMove(dir);
            Physics.IgnoreCollision(temp.GetComponent<Collider>(), transform.GetComponent<Collider>());
        }
    }
    private void FixedUpdate()
    {
       
        SelectTarget();
    }
}

