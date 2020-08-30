using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    List<string> PosibleScenes = new List<string>();

    private void OnTriggerEnter(Collider other)
    {
        if (PosibleScenes.Count != 0)
        {
            if (other.gameObject.tag == "Player")
            {
                string Scene = PosibleScenes[Random.Range(0, PosibleScenes.Count - 1)];
                SceneManager.LoadScene(Scene);
            }
        }
    }
}
