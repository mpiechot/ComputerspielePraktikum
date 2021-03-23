using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    
    public static void saveSceneName(string name){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedscenename.lol";
        FileStream stream = new FileStream(path, FileMode.Create);

        SceneName data = new SceneName(name);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static string loadSceneName(){
        string path = Application.persistentDataPath + "/savedscenename.lol";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SceneName data = formatter.Deserialize(stream) as SceneName;
            stream.Close();

            return data.name;
        }
        else{
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }





    public static void saveSceneCheckpoint(int checkpoint){
        Debug.Log(Application.persistentDataPath);
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedscenecheckpoint.lol";
        FileStream stream = new FileStream(path, FileMode.Create);

        SceneCheckpoint data = new SceneCheckpoint(checkpoint);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static int loadSceneCheckpoint(){
        string path = Application.persistentDataPath + "/savedscenecheckpoint.lol";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SceneCheckpoint data = formatter.Deserialize(stream) as SceneCheckpoint;
            stream.Close();

            return data.checkpoint;
        }
        else{
            Debug.LogError("Save file not found in " + path);
            return -1;
        }
    }










    public static void savePlayerData(Player player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.lol";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData loadPlayerData (){
        string path = Application.persistentDataPath + "/player.lol";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else{
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    [System.Serializable]
    class SceneName{
        public string name;

        public SceneName(string name){
            this.name = name;
        }
    }

    [System.Serializable]
    class SceneCheckpoint{
        public int checkpoint;

        public SceneCheckpoint(int checkpoint){
            this.checkpoint = checkpoint;
        }
    }

    

}

[System.Serializable]
public class PlayerData
{
    public int current_health;
    public int[] collected_keyIDs;

    public PlayerData(Player player){
        current_health = player.getCurrentHealth();
        collected_keyIDs = player.collectedKeys.ToArray();
    }
}