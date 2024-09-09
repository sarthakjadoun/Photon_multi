using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;

public class Pingshow : NetworkBehaviour
{
    [SerializeField] private TMP_Text pingText;
    void Start()
    {
        StartCoroutine(pingupdate());
    }
    IEnumerator pingupdate()
    {
        while (true)
        {
            if (Runner != null && Runner.IsRunning)
            {
                double ping = Runner.GetPlayerRtt(Runner.LocalPlayer) * 1000;

                pingText.text = $"Ping:{ping}ms";
                Debug.Log(ping);
            }
            yield return new WaitForSeconds(2);
        }
    }
}
