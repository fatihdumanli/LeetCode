using System.Security.Cryptography;
using System.Text;

namespace StringDictLib;

public class ListNode<T>
{
    public T val { get; set; }
    public ListNode<T> next { get; set; }

    public ListNode(T val)
    {
        this.val = val;
    }
}

public class HashSetStringDict : IStringDict
{
    private const int N_BUCKETS = 100;
    private ListNode<string>[] _buckets = new ListNode<string>[N_BUCKETS];


    public void Add(string word)
    {
        var (bucket, bucketIdx) = GetBucket(word);

        if (bucket == null)
        {
            _buckets[bucketIdx] = new ListNode<string>(word);
            return;
        }

        while (bucket.next != null)
        {
            bucket = bucket.next;
        }

        bucket.next = new ListNode<string>(word);
    }

    public bool Contains(string word)
    {
        var (bucket, _) = GetBucket(word);

        if (bucket == null)
            return false;

        while (bucket != null)
        {
            if (bucket.val == word)
                return true;

            bucket = bucket.next;
        }

        return false;
    }

    public void Remove(string word)
    {
        var (bucket, bucketIdx) = GetBucket(word);

        if (bucket == null)
            return;

        if (bucket.val == word)
        {
            _buckets[bucketIdx] = _buckets[bucketIdx].next;
            return;
        }

        while (bucket.next != null)
        {
            if (bucket.next.val == word)
            {
                bucket.next = bucket.next.next;
            }
            bucket = bucket.next;
        }
    }

    private int GetHash(string word)
    {
        using (var sha256Hash = SHA256.Create())
        {
            var plainBytes = Encoding.UTF8.GetBytes(word);
            var bytes = sha256Hash.ComputeHash(plainBytes);

            var integerValue = BitConverter.ToInt32(bytes, 0);

            if (integerValue < 0)
            {
                var abs = Math.Abs(integerValue);
                integerValue += (2 * abs);
            }

            return integerValue;
        }
    }

    private (ListNode<string>, int) GetBucket(string word)
    {
        var hash = GetHash(word);

        var bucketIdx = hash % N_BUCKETS;

        return (_buckets[bucketIdx], bucketIdx);
    }
}

