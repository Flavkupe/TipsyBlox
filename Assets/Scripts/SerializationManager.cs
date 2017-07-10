using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using UnityEngine;

[Serializable]
public class SaveData : ISerializable
{
    public DictionaryOfIntAndInt Scores = new DictionaryOfIntAndInt();

    public DictionaryOfIntAndInt Grades = new DictionaryOfIntAndInt();

    public List<int> test = new List<int>();

    public int MaxLevel = 0;

    public SaveData()
    {
    }

    public SaveData (SerializationInfo info, StreamingContext context)
    {
        //try
        //{
        //    Scores = (DictionaryOfIntAndInt)info.GetValue("Scores", typeof(DictionaryOfIntAndInt));
        //} catch {}

        try
        {
            Grades = (DictionaryOfIntAndInt)info.GetValue("Grades", typeof(DictionaryOfIntAndInt));
        }
        catch
        {
        }        

        try
        {
            MaxLevel = info.GetInt32("MaxLevel");
        } catch
        {
        }
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {        
        info.AddValue("Grades", Grades, typeof(DictionaryOfIntAndInt));
        info.AddValue("test", test, typeof(List<int>));
        info.AddValue("MaxLevel", MaxLevel);
    }    
}


public class SerializationManager : MonoBehaviour
{
    private static SerializationManager instance;

    public static SerializationManager Instance
    {
        get { return instance; }
    }    

    private string FilePath
    {
        get
        {
            return Application.persistentDataPath + "/SaveData.sf";
        }
    }

    public void Save()
    {
        try
        {            
            SaveData data = new SaveData();
            data.Grades = PlayerManager.Instance.Grades;            
            data.MaxLevel = PlayerManager.Instance.MaxLevel;
            data.test = new List<int>() { 1, 2, 3 };

            using (Stream stream = File.Open(FilePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Binder = new VersionDeserializerBinder();
                formatter.Serialize(stream, data);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
        }
    }

    public void Load()
    {
        try
        {
            if (!File.Exists(FilePath))
            {
                return;
            }

            SaveData data = new SaveData();
            using (Stream stream = File.Open(FilePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Binder = new VersionDeserializerBinder();
                data = formatter.Deserialize(stream) as SaveData;
            }

            if (data != null)
            {
                PlayerManager.Instance.Grades = data.Grades;
                PlayerManager.Instance.MaxLevel = data.MaxLevel;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
        }
    }

    public sealed class VersionDeserializerBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            if (!string.IsNullOrEmpty(assemblyName) && ! string.IsNullOrEmpty(typeName))
            {
                assemblyName = Assembly.GetExecutingAssembly().FullName;
                Type typeToDeserialize = Type.GetType(string.Format("{0}, {1}", typeName, assemblyName));
                return typeToDeserialize;
            }

            return null;
        }
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void DeleteProgress()
    {
        PlayerManager.Instance.DeleteProgress();
        if (File.Exists(FilePath))
        {
            File.Delete(FilePath);
        }

        this.Save();
    }
}
