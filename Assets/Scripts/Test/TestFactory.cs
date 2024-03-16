using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestFactory : ITestFactory
{
    public void CreateCube(CubeType type)
    {
        switch (type)
        {
            case CubeType.Default:
                CreateDefaultCube();
                break;
        }
    }

    public void CreateDefaultCube()
    {
        MonoBehaviour.print("Create default cubes");

    }
}
public enum CubeType
{
    Default, //обычный кубик
    Mega, // кубик размером 3 на 3 на 3
    Giga, // кубик размером 9 на 9 на 9
    Black, // кубик черного цвета
    MyCube
}
