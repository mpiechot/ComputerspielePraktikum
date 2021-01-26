using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    public bool has_checkpoints;

    // Start is called before the first frame update
    void Start()
    {
        // do all the stuff that must happen when you directly load this lvl (by pressing load game in the menu)
        if(Universal.load_game){

            if(has_checkpoints){
                // load checkpoint via SaveSystem
                int checkpoint_id = SaveSystem.loadSceneCheckpoint();

                // access checkpoint and enable all furnitures ...
                GameObject checkpoint = GameObject.Find("Checkpoint" + checkpoint_id);

                // access start position of this checkpoint (CheckpointStartPosition) and place olaf respectively
                Vector3 position = checkpoint.GetComponent<CheckpointStartPosition>().position;
                Vector3 rotation = checkpoint.GetComponent<CheckpointStartPosition>().rotation;
                // ...
            }
            // else, all objects are already loaded?

            // load olafs current state - Health etc...
            PlayerData player_data = SaveSystem.loadPlayerData();

            // adapt all attributes (Health etc.) of Olaf with the loaded Player data.
            // ...



            // set load game back to false, else it would act wrong in the next scene
            Universal.load_game = false;
        }
    }

}
