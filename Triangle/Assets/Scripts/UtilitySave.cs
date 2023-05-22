using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class UtilitySave
{ 
    public static void SecureSerialize(string path, Data d)
    {
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(d.name);
                bw.Write(d.number);
                fs.Close();
            }
        }
           
    }

    public static Data SecureDeserialize(string path)
    {
        Data d = new Data();
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                d.name = br.ReadString();
                d.number = br.ReadInt32();
                fs.Close();
                return d;
            }
        }
            
    }
}
