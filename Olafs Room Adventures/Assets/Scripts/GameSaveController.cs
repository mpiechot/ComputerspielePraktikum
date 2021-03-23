using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaveController : MonoBehaviour
{

    public bool has_checkpoints;
    public GameObject[] checkpoints;
    public Player olaf_player;

    // Start is called before the first frame update
    void Start()
    {   
        //// do all the stuff that must happen when you directly load this lvl (by pressing load game in the menu)
        //if(Universal.load_game){
        //    if(has_checkpoints){
        //        // load checkpoint via SaveSystem
        //        int checkpoint_id = SaveSystem.loadSceneCheckpoint();

        //        // access checkpoint and enable all furnitures ...
        //        GameObject checkpoint = checkpoints[checkpoint_id];

        //        Vector3 position = checkpoint.GetComponent<CheckpointStartPosition>().position;
        //        olaf_player.transform.position = position;


        //        // access stored player specific informations (e.g. health) if necessary
        //        PlayerData player_data = SaveSystem.loadPlayerData();

        //        // assign attributes to the player
        //        olaf_player.setCurrentHealth(player_data.current_health);
        //    }
        //    else{
        //        // i think there is nothing else to do? No checkpoints -> only 1 room -> everything will be loaded anyway and player data are set to their desired values as well
        //    }

        //    // set load game back to false, else it would act wrong in the next scene
        //    Universal.load_game = false;
        //}
        //else{
        //    if(has_checkpoints){
        //        save(0); // assume 0 as first checkpoint
        //    }
        //    else{
        //        save();
        //    }
        //}
    }

    public void Load(CheckpointStartPosition start)
    {
        Debug.Log($"Start: " + start.position);
        // do all the stuff that must happen when you directly load this lvl (by pressing load game in the menu)
        if (Universal.load_game)
        {
            if (has_checkpoints)
            {
                // load checkpoint via SaveSystem
                Vector3 position = start.position;
                olaf_player.transform.position = position;

                // access stored player specific informations (e.g. health) if necessary
                PlayerData player_data = SaveSystem.loadPlayerData();
                Debug.Log($"Load data: {player_data.current_health}");

                // assign attributes to the player
                olaf_player.setCurrentHealth(player_data.current_health);
                olaf_player.InitCollectedKeys(player_data.collected_keyIDs);
            }
            else
            {
                // i think there is nothing else to do? No checkpoints -> only 1 room -> everything will be loaded anyway and player data are set to their desired values as well
            }

            // set load game back to false, else it would act wrong in the next scene
            Universal.load_game = false;
        }
        else
        {
            if (has_checkpoints)
            {
                save(0); // assume 0 as first checkpoint
            }
            else
            {
                save();
            }
        }
    }

    public void save(int checkpoint){
        StartCoroutine("indicateSave");

        // overwrite currently stored scene name
        SaveSystem.saveSceneName(SceneManager.GetActiveScene().name);

        // overwrite currently stored checkpoint
        SaveSystem.saveSceneCheckpoint(checkpoint);

        // overwrite currently stored player data
        SaveSystem.savePlayerData(olaf_player);
    }

    public void save(){
        StartCoroutine("indicateSave");

        // overwrite currently stored scene name
        SaveSystem.saveSceneName(SceneManager.GetActiveScene().name);

        // overwrite currently stored player data
        SaveSystem.savePlayerData(olaf_player);
    }


    private IEnumerator indicateSave(){
        // show save icon
        Debug.Log("show icon");
        yield return new WaitForSeconds(2);
        // hide save ivon
        Debug.Log("hide icon");
    }


    // test
    void Update(){
        if(Input.GetKeyDown(KeyCode.B)){
            save(1);
        }
    }

}
