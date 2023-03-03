using System.Collections;
using System.Runtime.Serialization;
using UnityEngine;

namespace DevKacper.SaveSystem
{
    public class TransformSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            Transform transform = (Transform)obj;

            Vector3 pos = transform.position;
            info.AddValue("posX", pos.x);
            info.AddValue("posY", pos.y);
            info.AddValue("posZ", pos.z);

            Vector3 scale = transform.localScale;
            info.AddValue("scaleX", scale.x);
            info.AddValue("scaleY", scale.y);
            info.AddValue("scaleZ", scale.z);

            Quaternion rotation = transform.rotation;
            info.AddValue("rotX", rotation.x);
            info.AddValue("rotY", rotation.y);
            info.AddValue("rotZ", rotation.z);
            info.AddValue("rotW", rotation.w);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Transform transform = (Transform)obj;

            transform.position = new Vector3((float)info.GetValue("posX", typeof(float)), (float)info.GetValue("posY", typeof(float)), (float)info.GetValue("posZ", typeof(float)));
            transform.localScale = new Vector3((float)info.GetValue("scaleX", typeof(float)), (float)info.GetValue("scaleY", typeof(float)), (float)info.GetValue("scaleZ", typeof(float)));
            transform.rotation = new Quaternion((float)info.GetValue("rotX", typeof(float)), (float)info.GetValue("rotY", typeof(float)), (float)info.GetValue("rotZ", typeof(float)), (float)info.GetValue("rotW", typeof(float)));

            return transform;
        }
    }
}