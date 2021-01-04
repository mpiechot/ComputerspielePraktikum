using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OlafStatesH : MonoBehaviour
{
    public bool has_key = false;

    public void Update(){
        if(Input.GetKeyDown("k")){
            Debug.Log("save scene name");
            saveSceneName();
        }

        if(Input.GetKeyDown("l")){
            Debug.Log("load scene");
            loadScene();
        }
    }

    public void saveSceneName(){
        SaveSystem.saveSceneName(SceneManager.GetActiveScene().name);
    }

    public void loadScene(){
        string name = SaveSystem.loadSceneName();
        if(name != null){
            SceneManager.LoadScene(name);
        }
        else{
            Debug.Log("Wugabuga");
        }
    }


    public void savePlayer(){
        SaveSystem.savePlayer(this);
    }

    public void loadPlayer(){
        PlayerData data = SaveSystem.LoadPlayer();

        has_key = data.has_key;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        Debug.Log(position);
        transform.position = position;
    }
}
