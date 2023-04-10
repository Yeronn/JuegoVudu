using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

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

        else if (sceneName.Equals(Scenes.Inventario.ToString()))
        {
            if (!GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()))
            {
                Instantiate(munecoPrefab);
                GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()).transform.position = new Vector3(-0.82f, -0.53f, 0);

            }
            else
            {
                Debug.Log("Entro a la posicion correcta");
                GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()).transform.position = new Vector3(-0.82f,-0.53f,0);
            }
        }
        else
        {
            GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()).transform.position = new Vector3(-0.82f, -0.53f, 0);
            GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()).GetComponent<SpriteRenderer>().flipX = true;
        }

    }

    public void PreviousScene()
    {
        //GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()).SetActive(true);
        Destroy(GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()));
        SceneManager.LoadScene(previousScene);
    }

    public void FightScene()
    {
        if (previousScene.Equals(Scenes.BattleScene1.ToString()))
        {
            //GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()).SetActive(true);
            SceneManager.LoadScene(Scenes.Fight1.ToString());
        }
        else if (previousScene.Equals(Scenes.BattleScene2.ToString()))
        {
            //GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()).SetActive(true);
            SceneManager.LoadScene(Scenes.Fight2.ToString());
        }
        else if (previousScene.Equals(Scenes.BattleScene3.ToString()))
        {
            //GameObject.FindGameObjectWithTag(Tags.Muneco.ToString()).SetActive(true);
            SceneManager.LoadScene(Scenes.Fight3.ToString());
        }
    }
}
