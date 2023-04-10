using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject munecoPrefab, monstruoPrefab;
    public static string previousScene;
    private enum Scenes
    {
        Menu,
        Inventario,
        BattleScene1,
        BattleScene2,
        BattleScene3,
        Fight1,
        Fight2,
        Fight3
    }
    public void LoadScene(string sceneName)
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);

        if (sceneName.Equals(Scenes.Menu.ToString()))
        {
            Destroy(GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()));
        }

        if (sceneName.Equals(Scenes.Inventario.ToString()))
        {
            if (!GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()))
            {
                Instantiate(munecoPrefab);
            }
            else
            {
                GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()).transform.position = new Vector3(0f,1f,0);
            }
        }

        if (sceneName.Equals(Scenes.Fight1.ToString()))
        {
            //GameObject.FindGameObjectWithTag("Monstruo").transform.position = new Vector3(0.18f,1.18f,0);
            
        }
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(previousScene);
    }

    public void FightScene()
    {
        if (previousScene.Equals(Scenes.BattleScene1.ToString()))
        {
            SceneManager.LoadScene(Scenes.Fight1.ToString());
            Debug.Log("Posicionando monstruo 1");
            monstruoPrefab.transform.position = new Vector3(0.18f, 1.18f, 0);
            monstruoPrefab.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (previousScene.Equals(Scenes.BattleScene2.ToString()))
        {
            SceneManager.LoadScene(Scenes.Fight2.ToString());
        }
        else if (previousScene.Equals(Scenes.BattleScene3.ToString()))
        {
            SceneManager.LoadScene(Scenes.Fight3.ToString());
        }
    }
}
