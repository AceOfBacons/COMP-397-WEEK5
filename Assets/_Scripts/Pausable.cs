using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class Pausable : MonoBehaviour
{
    public List<MonoBehaviour> scripts;
    public List<NavMeshAgent> agents;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }


    public void Pause()
    {
        isPaused = !isPaused;
        foreach(var script in scripts)
        {
            script.enabled = !isPaused;
        }

        foreach (var agent in agents)
        {
            agent.enabled = !isPaused;
        }
    }
}
