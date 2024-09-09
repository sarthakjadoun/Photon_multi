using Fusion;
using UnityEngine;public class spawnclass : SimulationBehaviour, IPlayerJoined{    [SerializeField] private GameObject playerCharacter;

    public void PlayerJoined(PlayerRef player)
    {
        Runner.Spawn(playerCharacter, new Vector3(0f, 1f, 0f), Quaternion.identity);
    }
}