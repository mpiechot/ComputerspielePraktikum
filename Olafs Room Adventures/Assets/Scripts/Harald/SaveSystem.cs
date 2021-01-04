using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    
    public static void saveSceneName(string name){
        Debug.Log(Application.persistentDataPath);
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

    public static void savePlayer(OlafStatesH player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedscenename.lol";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer (){
        string path = Application.persistentDataPath + "/player.fun";
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

}
