using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkRunnerHandler : MonoBehaviour
{

    public NetworkRunner networkRunnerPrefab;

    private NetworkRunner networkRunner;

    // Start is called before the first frame update
    void Start()
    {
        networkRunner = Instantiate(networkRunnerPrefab);
        networkRunner.name = "Network Runner";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HostGame()
    {
        var clientTask = InitializedNetworkRunner(networkRunner, GameMode.Host, NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null);
    }

    public void JoinGame()
    {
        var clientTask = InitializedNetworkRunner(networkRunner, GameMode.Client, NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null);
    }

    public void QuickGame()
    {
        var clientTask = InitializedNetworkRunner(networkRunner, GameMode.AutoHostOrClient, NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null);
    }



    protected virtual Task InitializedNetworkRunner(NetworkRunner runner, GameMode gameMode, NetAddress address, SceneRef scene, Action<NetworkRunner> initialized)
    {
        var sceneObjectProvider = runner.GetComponents(typeof(MonoBehaviour)).OfType<INetworkSceneManager>().FirstOrDefault();

        if (sceneObjectProvider == null)
        {
            sceneObjectProvider = runner.gameObject.AddComponent<NetworkSceneManagerDefault>();
        }

        runner.ProvideInput = true;

        return runner.StartGame(new StartGameArgs
        {
            GameMode = gameMode,
            Address = address,
            Scene = scene,
            SessionName = "test",
            Initialized = initialized,
            SceneManager = sceneObjectProvider,

        });

    }

}
