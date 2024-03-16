using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TestView : MonoBehaviour
{
    [Inject] TestFactory testFactory;
    // Start is called before the first frame update
    void Start()
    {
        testFactory?.CreateCube(CubeType.Default);
    }
}
