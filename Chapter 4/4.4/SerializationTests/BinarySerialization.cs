using HelpersLibrary;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationTests
{
    public class BinarySerialization : IRun
    {
        public void Run()
        {
            UsingBinarySerializer();
            SerializationEvents();
        }

        private void UsingBinarySerializer()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var p = new PersonSerializable()
            {
                Id = 1,
                Firstname = "john"
            };

            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("data.bin", FileMode.Create))
            {
                formatter.Serialize(stream, p);
            }

            using (Stream stream = new FileStream("data.bin", FileMode.Open))
            {
                PersonSerializable dp = (PersonSerializable)formatter.Deserialize(stream);
            }
        }

        private void SerializationEvents()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            var p = new SamplePerson
            {
                Id = 123,
                Name = "Kuba"
            };

            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("data1.bin", FileMode.Create))
            {
                formatter.Serialize(stream, p);
            }

            using (Stream stream = new FileStream("data1.bin", FileMode.Open))
            {
                SamplePerson dp = (SamplePerson)formatter.Deserialize(stream);
            }
        }
        
        /// <summary>
        /// Klasa ma jeden atrybut wyłączony z serializacji
        /// Binarna serializacja bierze pod uwagę także prywane zmienne 
        /// XmlSerializer nie serializuje prywatnych
        /// </summary>
        [Serializable]
        public class SamplePerson
        {
            public int Id { get; set; }
            public string Name { get; set; }
            [NonSerialized]
            private bool isDirty = false;

            [OnSerializing()]
            internal void OnSerializingMethod(StreamingContext context)
            {
                Console.WriteLine("OnSerializing");
            }

            [OnSerialized()]
            internal void OnSerializedMethod(StreamingContext context)
            {
                Console.WriteLine("OnSerialized");
            }

            [OnDeserialized()]
            internal void OnDeserializedmethod(StreamingContext context)
            {
                Console.WriteLine("OnDeserialized");
            }

            [OnDeserializing()]
            internal void OnDeserializingMethod(StreamingContext context)
            {
                Console.WriteLine("OnDeserializing");
            }
        }

        [Serializable]
        public class PersonComplex : ISerializable
        {
            public int Id { get; set; }
            public string Name { get; set; }
            private bool isDirty = false;

            public PersonComplex() { }

            protected PersonComplex(SerializationInfo info, StreamingContext context)
            {
                Id = info.GetInt32("Value1");
                Name = info.GetString("Value2");
                isDirty = info.GetBoolean("Value3");
            }

            [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter = true)]
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("Value1", Id);
                info.AddValue("Value1", Name);
                info.AddValue("Value1", isDirty);
            }
        }
    }
}
