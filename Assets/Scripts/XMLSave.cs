using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using UnityEngine;

public static class XMLSave<ObjectType>
{
    public static void Save(object obj, string fileName)
    {
        StreamWriter fs = new StreamWriter(fileName);

        try
        {
            
            XmlSerializer xsr = new XmlSerializer(typeof(ObjectType));
            xsr.Serialize(fs, obj);
        }
        catch (SerializationException e)
        {
            Debug.Log("Failed to serialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            fs.Close();
        }
    }

    public static ObjectType Load(string fileName)
    {
        if (!File.Exists(fileName))
            return default(ObjectType);

        StreamReader fs = new StreamReader(fileName);
        ObjectType obj;
        try
        {
            XmlSerializer xsr = new XmlSerializer(typeof(ObjectType));
            obj = (ObjectType)xsr.Deserialize(fs);
        }
        catch (SerializationException e)
        {
            Debug.Log("Failed to deserialize. Reason: " + e.Message);
            throw;
        }
        finally
        {
            fs.Close();
        }
        return obj;
    }
}