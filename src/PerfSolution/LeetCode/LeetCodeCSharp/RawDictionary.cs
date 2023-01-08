//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace LeetCodeCSharp
//{

//    using System;
//    using System.Collections;
//    using System.Diagnostics;
//    using System.Diagnostics.Contracts;
//    using System.Runtime.Serialization;
//    using System.Security.Permissions;

//    [DebuggerDisplay("Count = {Count}")]
//    public unsafe struct RawDictionary<TKey, TValue> 
//    {
//        private unsafe struct Entry
//        {
//            public int hashCode;    // Lower 31 bits of hash code, -1 if unused
//            public Entry* next;        // Index of next entry, -1 if last
//            public TKey* key;           // Key of entry
//            public TValue* value;         // Value of entry
//        }

//        private int[] buckets;
//        private Entry[] entries;
//        private int count;


//        public RawDictionary()
//        {
//            Initialize();
//        }


//        public int Count
//        {
//            get { return count; }
//        }


//        public void Clear()
//        {
//            if (count > 0)
//            {
//                for (int i = 0; i < buckets.Length; i++) 
//                    buckets[i] = -1;

//                Array.Clear(entries, 0, count);

//            }
//        }

//        public bool ContainsKey(TKey key)
//        {
//            return FindEntry(key) >= 0;
//        }

//        public bool ContainsValue(TValue value)
//        {
//            if (value == null)
//            {
//                for (int i = 0; i < count; i++)
//                {
//                    if (entries[i].hashCode >= 0 && entries[i].value == null) return true;
//                }
//            }
//            else
//            {
//                EqualityComparer<TValue> c = EqualityComparer<TValue>.Default;
//                for (int i = 0; i < count; i++)
//                {
//                    if (entries[i].hashCode >= 0 && c.Equals(entries[i].value, value)) return true;
//                }
//            }
//            return false;
//        }


//        private int FindEntry(TKey key)
//        {
//            if (buckets != null)
//            {
//                int hashCode = key.GetHashCode() & 0x7FFFFFFF;
//                int index = hashCode % buckets.Length;

//                for (int i = buckets[index]; i >= 0; i = entries[i].next)
//                {
//                    if (entries[i].hashCode == hashCode && key.Equals(entries[i].key)) 
//                        return i;
//                }
//            }
//            return -1;
//        }

//        private void Initialize()
//        {
//            int size = 1000;
//            buckets = new int[size];
//            for (int i = 0; i < buckets.Length; i++) 
//                buckets[i] = -1;
//            entries = new Entry[size];
//        }

//        public void Insert(TKey key, TValue value)
//        {
//            int hashCode = key.GetHashCode() & 0x7FFFFFFF;
//            int targetBucket = hashCode % buckets.Length;

//            int index = buckets[targetBucket];
//            if(index < 0)
//            {
//                entries[targetBucket].hashCode = hashCode;
//                entries[targetBucket].next = -1;
//                entries[targetBucket].key = key;
//                entries[targetBucket].value = value;
//                buckets[targetBucket] = index;

//                count++;
//                return;
//            }

//            var entry = entries[index];
//            while (entry.next != null)
//            {
//                if (entry.hashCode == hashCode && key.Equals(entry.key)))
//                {
//                    entries[index].value = value;
//                    return;
//                }
//            }
            


//            for (index = buckets[targetBucket]; index >= 0; index = entries[index].next)
//            {
//                // Key exists
//                if (entries[index].hashCode == hashCode && key.Equals(entries[index].key))
//                {
//                    entries[index].value = value;
//                    return;
//                }
//            }


//            if (index < 0)
//                index = targetBucket;

//            entries[index].hashCode = hashCode;
//            entries[index].next = buckets[targetBucket];
//            entries[index].key = key;
//            entries[index].value = value;
//            buckets[targetBucket] = index;

//            count++;
//        }

       

//        public bool TryGetValue(TKey key, out TValue value)
//        {
//            int i = FindEntry(key);
//            if (i >= 0)
//            {
//                value = entries[i].value;
//                return true;
//            }
//            value = default(TValue);
//            return false;
//        }

//        // This is a convenience method for the internal callers that were converted from using Hashtable.
//        // Many were combining key doesn't exist and key exists but null value (for non-value types) checks.
//        // This allows them to continue getting that behavior with minimal code delta. This is basically
//        // TryGetValue without the out param
//        internal TValue GetValueOrDefault(TKey key)
//        {
//            int i = FindEntry(key);
//            if (i >= 0)
//            {
//                return entries[i].value;
//            }
//            return default(TValue);
//        }

//    }

//}
