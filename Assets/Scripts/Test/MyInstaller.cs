using UnityEngine;
using Zenject;

public class MyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<TestFactory>().AsSingle();
    }
}