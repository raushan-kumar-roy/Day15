namespace HashTableProblemm
{
   public class MyMapNode<K,V>
    {
        public readonly int size;
        public readonly LinkedList<KeyValue<K, V>>[] items;

        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }

        public struct KeyValue<K, V>
        {
            public K Key { get; set; }
            public V Value { get; set; }
        }
        public int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        public V Get(K Key)
        {
            int position = GetArrayPosition(Key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);

            foreach (KeyValue<K, V> keyValues in linkedlist)
            {
                if (item.Key.Equals(Key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }

        public void Add(K Key, V Value)
        {
            int position = GetArrayPosition(Key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = Key, Value = Value };
            linkedlist.AddLast(item);
        }
        public void Remove(K Key)
        {
            int position = GetArrayPosition(Key);
            LinkedList<KeyValue<K, V>> linklist = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linklist)
            {
                if (item.Key.Equals(Key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linklist.Remove(foundItem);
            }
        }
        public LinkedList<KeyValuePair<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValuePair<K, V>> linkedlist = items[position];
            var linkedList = items[position];
            if (linkedlist == null)
            {
                linkedlist = new LinkedList<KeyValuePair<K, V>>();
                items[position] = linkedlist;
            }

            return linkedlist;
        }


    }
}
