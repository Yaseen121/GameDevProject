using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController control;
    public bool[] levelsUnlocked;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
            Debug.Log("HERE");
            Load();
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
    public void Save()
    {
        string filename = Application.persistentDataPath + "/playInfo.dat";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(filename, FileMode.OpenOrCreate);
        LevelSaveData lsd = new LevelSaveData();
        lsd.levelsUnlocked = levelsUnlocked;

        bf.Serialize(file, lsd);
        file.Close();
    }

    public void Load()
    {
        string filename = Application.persistentDataPath + "/playInfo.dat";
        if (File.Exists(filename))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filename, FileMode.Open);
            LevelSaveData pd = (LevelSaveData)bf.Deserialize(file);
            file.Close();
            levelsUnlocked = pd.levelsUnlocked;
        }
        else {
            //Adjust according to level nums
            levelsUnlocked = new bool[3];
            levelsUnlocked[0] = true;
            levelsUnlocked[1] = false;
            levelsUnlocked[2] = false;
        }
    }
}
