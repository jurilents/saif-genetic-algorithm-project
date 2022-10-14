using Leopotam.Ecs;
using UnityEngine;

public class GameStartup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;


    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
        // .Add(new PlayerHealthSystem());
        _systems.Init();
    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        _systems.Destroy();
        _world.Destroy();
    }
}