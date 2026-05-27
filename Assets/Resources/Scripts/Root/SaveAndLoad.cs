using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveAndLoad : MonoBehaviour
{
    
    public void Save<T>(T saveInformation,string path)
    {
        if (File.Exists(path))
        {
            SpareSave(path,saveInformation);
           
            File.Delete(path);
        }
        
        BinaryFormatter binary = new BinaryFormatter();
        FileStream ff = new FileStream(path,FileMode.Create);
        

        binary.Serialize(ff,saveInformation);
        
        ff.Close();

        Debug.Log("save" + saveInformation.GetType());
    }

   
    public T Load<T>(T currentinfo,string path)
    {
       
        if(File.Exists(path))
        {
          
            BinaryFormatter binary = new BinaryFormatter();
            FileStream ff = new FileStream(path, FileMode.Open);   
            currentinfo = (T)binary.Deserialize(ff);
            ff.Close();
           
        }
        else
        {
          currentinfo =  SpareSaveLoad(path,currentinfo);
        }
        return currentinfo;
    }


    public void SpareSave<T>(string path, T saveinformation)
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream fa = new FileStream(path, FileMode.Open);
        saveinformation = (T)binary.Deserialize(fa);

        fa.Close();

        BinaryFormatter bin = new BinaryFormatter();
        FileStream ff = new FileStream(path + "sparesave", FileMode.Create);

        bin.Serialize(ff, saveinformation);

        ff.Close();

    }
    public T SpareSaveLoad<T>(string path,T saveInfo)
    {
        
        if (File.Exists(path + "sparesave"))
        {

            BinaryFormatter binary = new BinaryFormatter();
            FileStream ff = new FileStream(path + "sparesave", FileMode.Open);
            saveInfo = (T)binary.Deserialize(ff);
            ff.Close();
            Debug.Log("fff");

        }

        return saveInfo;
    }
}
