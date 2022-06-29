public class CacheNode {
    public int Key { get; set; }
    public int Val { get; set; }
    public CacheNode Next { get; set; }
    public CacheNode Prev { get; set; }
}

public class LRUCache
{
    private int _capacity;
    private CacheNode _head;

    private Dictionary<int, CacheNode> _hashmap = new Dictionary<int, CacheNode>();

    public LRUCache(int capacity)
    {
        _capacity = capacity;
    }

    public int Get(int key)
    {
        return -1;
    }

    public void Put(int key, int value)
    {
    }
}