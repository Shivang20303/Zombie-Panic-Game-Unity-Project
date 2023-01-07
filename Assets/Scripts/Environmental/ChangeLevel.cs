using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : Triggerable
{
    public string sceneName;

    public override void Trigger (TriggerAction action)
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnDrawGizmos ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, Vector3.one * 0.25f);
    }
}
