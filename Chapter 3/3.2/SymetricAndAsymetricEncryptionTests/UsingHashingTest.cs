using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymetricAndAsymetricEncryptionTests
{
    public class UsingHashingTest : IRun
    {
        public void Run()
        {
            HashingTest();
            UsingSHA256Managed(new string[]{ "Ala ma kota", "Miasto Wroclaw", "Ala ma kota" });
        }

        private void HashingTest()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            var stringSet = new HashSet<string>();
            stringSet.Add("Kuba");
            stringSet.Add("Ania");
            stringSet.Add("Jan");
            stringSet.Add("Bonifacy");
            stringSet.Add("Kuba");
            foreach (var item in stringSet)
            {
                Console.WriteLine(item);
            }
        }

        private void UsingSHA256Managed(string[] data)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            SHA256 sha256 = SHA256.Create();

            List<byte[]> hashes = new List<byte[]>(data.Length);

            for (int i = 0; i < data.Length; i++)
            {
                var hash = sha256.ComputeHash(byteConverter.GetBytes(data[i]));
                hashes.Add(hash);
            }
            
            if (hashes.Count > 2)
            {
                Console.WriteLine(hashes[0].SequenceEqual(hashes[1]));
                Console.WriteLine(hashes[0].SequenceEqual(hashes[2]));
                Console.WriteLine(hashes[1].SequenceEqual(hashes[2]));
            }
        }
    }


    /// <summary>
    /// For each item that you add, you have to loop through all existing items. 
    /// This doesn’t scale well and leads to performance problems when you have a large amount of items. 
    /// It would be nice if you somehow needed to check only a small subgroup instead of all the items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Set<T>
    {
        private List<T> list = new List<T>();

        public void Insert(T item)
        {
            if (!Contains(item))
                list.Add(item);
        }

        public bool Contains(T item)
        {
            foreach (T member in list)
            {
                if (member.Equals(item))
                    return true;
            }
            return false;
        }
    }

    class HashedSet<T>
    {
        private List<T>[] buckets = new List<T>[100];

        public void Insert(T item)
        {
            int bucket = GetBucket(item.GetHashCode());
            if (Contains(item, bucket))
                return;
            if (buckets[bucket] == null)
                buckets[bucket] = new List<T>();
            buckets[bucket].Add(item);
        }

        public bool Contains(T item)
        {
            return Contains(item, GetBucket(item.GetHashCode()));
        }

        private int GetBucket(int hashcode)
        {
            // A Hash code can be negative. To make sure that you end up with a positive
            // value cast the value to an unsigned int. The unchecked block makes sure that
            // you can cast a value larger then int to an int safely.
            unchecked
            {
                return (int)((uint)hashcode % (uint)buckets.Length);
            }
        }

        private bool Contains(T item, int bucket)
        {
            if (buckets[bucket] != null)
                foreach (T member in buckets[bucket])
                    if (member.Equals(item))
                        return true;
            return false;
        }
    }
}
