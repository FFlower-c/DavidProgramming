using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

[Serializable]
public class ObjectInfo
{
    public string name;
    public Vector3 Pos;
    public Quaternion rotation;
    public Vector3 scale;
}

[Serializable]
public class ObjectList
{
    public List<ObjectInfo> objects;
}
public class SaveAndLoad : MonoBehaviour
{
    private static readonly int Key = 1;
    void Start()
    {
        LoadScene();
    }
    public static void SaveScene()
    {
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        List<ObjectInfo> objectInfos = new List<ObjectInfo>();

        foreach (GameObject obj in objects)
        {
            ObjectInfo objectInfo = new ObjectInfo();
            objectInfo.name = obj.name;
            objectInfo.Pos = obj.transform.position;
            objectInfo.rotation = obj.transform.rotation;
            objectInfo.scale = obj.transform.localScale;
            objectInfos.Add(objectInfo);
        }

        string json = JsonUtility.ToJson(new ObjectList { objects = objectInfos });
        string path = Application.streamingAssetsPath + "/SceneData.json";
        string encryptedJson = EncryptJson(json, Key);
        using (StreamWriter streamWriter = new StreamWriter(path))
        {
            streamWriter.Write(encryptedJson);
            streamWriter.Close();
            streamWriter.Dispose();
        }
    }

    public static void LoadScene()
    {
        string json;
        string path = Application.streamingAssetsPath + "/SceneData.json";

        using (StreamReader streamReader = new StreamReader(path))
        {
            json = streamReader.ReadToEnd();
            streamReader.Close();
        }
        string Json = DecryptJson(json, Key);

        ObjectList objectList = JsonUtility.FromJson<ObjectList>(Json);

        foreach (ObjectInfo objectInfo in objectList.objects)
        {
            GameObject obj = new GameObject(objectInfo.name);
            obj.transform.position = objectInfo.Pos;
            obj.transform.rotation = objectInfo.rotation;
            obj.transform.localScale = objectInfo.scale;
        }
        


    }

    private static string EncryptJson(string json, int key)
    {
        char[] charArray = json.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            charArray[i] = (char)(charArray[i] ^ key);
        }
        return new string(charArray);
    }


    private static string DecryptJson(string encryptedJson, int key)
    {
        return EncryptJson(encryptedJson, key);
    }

}

