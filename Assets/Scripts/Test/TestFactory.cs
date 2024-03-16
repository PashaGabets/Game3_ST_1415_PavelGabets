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
    Default, //������� �����
    Mega, // ����� �������� 3 �� 3 �� 3
    Giga, // ����� �������� 9 �� 9 �� 9
    Black, // ����� ������� �����
    MyCube
}
