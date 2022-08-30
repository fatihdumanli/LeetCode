namespace DesignHashset;

public class ListNode
{
    public int val { get; set; }
    public ListNode next { get; set; }

    public ListNode(int val)
    {
        this.val = val;
    }
}

public class MyHashSet
{
    private const int N_BUCKETS = 20;
    private ListNode[] _buckets = new ListNode[N_BUCKETS];

    public MyHashSet()
    {
    }

    public void Add(int key)
    {
        if(Contains(key))
            return;

        // hash >= 0 && hash <= 19
        var hash = key % N_BUCKETS;

        var bucketHead = _buckets[hash];

        if (bucketHead == null)
        {
            _buckets[hash] = new ListNode(key);
        }
        else
        {
            var ptr = _buckets[hash];

            while(ptr.next != null)
            {
                ptr = ptr.next;
            }

            ptr.next = new ListNode(key);
        }
    }

    public void Remove(int key)
    {
        var hash = key % N_BUCKETS;

        var bucketHead = _buckets[hash];

        if(bucketHead == null)
            return;

        if(bucketHead.val == key)
        {
            _buckets[hash] = _buckets[hash].next;
            return;
        }

        var ptr = bucketHead;

        while(ptr != null && ptr.next != null)
        {
            if(ptr.next.val == key)
            {
                ptr.next = ptr.next.next;
            }

            ptr = ptr.next;
        }
    }

    public bool Contains(int key)
    {
        var hash = key % N_BUCKETS;

        var head = _buckets[hash];

        if (head == null)
            return false;

        while(head != null)
        {
            if(head.val == key)
                return true;

            head = head.next;
        }

        return false;
    }
}
