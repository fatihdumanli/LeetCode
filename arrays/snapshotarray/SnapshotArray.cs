namespace SnapshotArrayNs;

// https://leetcode.com/problems/snapshot-array/
public class SnapshotArray
{
    private int _length;
    private int _snapCalls = 0;

    private List<Dictionary<int, int>> _arrayHistory =
        new List<Dictionary<int, int>>();

    public SnapshotArray(int length)
    {
        _length = length;

        for (int i = 0; i < length; i++)
        {
            _arrayHistory.Add(new Dictionary<int, int>() { { 0, 0 } });
        }
    }

    public void Set(int index, int val)
    {
        var snap_id = _snapCalls;

        if(_arrayHistory[index].ContainsKey(snap_id))
        {
            _arrayHistory[index][snap_id] = val;
            return; 
        }

        _arrayHistory[index].Add(snap_id, val);
    }

    public int Snap()
    {
        return _snapCalls++;
    }

    public int Get(int index, int snap_id)
    {
        var res = 0;

        var operations = _arrayHistory[index];
        
        foreach(var item in operations)
        {
            if (item.Key > snap_id)
            {
                return res;
            }

            res = item.Value;
        }

        return res;
    }
}