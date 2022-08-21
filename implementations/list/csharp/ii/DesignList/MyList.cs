namespace DesignList;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException(int val) : base($"The item {val} does not exist.")
    {
    }
}

public class MyList
{
    public int Count 
    {
        get {
            return _ptr;
        }
    }
    
    public int Capacity 
    {
        get {
            return _array.Length;
        }
    }

    private readonly int INITIAL_CAPACITY = 4;
    private int[] _array;
    private int _ptr = 0;

    public MyList()
    {
        _array = new int[INITIAL_CAPACITY];
    }

    public MyList(int capacity)
    {
        INITIAL_CAPACITY = capacity;
        _array = new int[INITIAL_CAPACITY];
    }

    public void Add(int val)
    {
        if(_ptr == _array.Length)
        {
            Resize();
        }

        _array[_ptr++] = val;
    }

    public bool Contains(int val)
    {
        for(int i = 0; i < _ptr; i++)
        {
            if(_array[i] == val)
                return true;
        }

        return false;
    }

    public void RemoveFirst(int val)
    {
        var index = -1;

        for(int i = 0; i < _ptr; i++)
        {
            if(_array[i] == val) 
            {
                index = i;
                break;
            }
        }

        if (index == -1) 
        {
            throw new ItemNotFoundException(val);
        }

        for(int i = index; i < _ptr; i++)
        {
            if(i + 1 >= _array.Length)
            {
                _array[i] = 0;
                break;
            }

            _array[i] = _array[i + 1];
        }
        _ptr--;
    }

    public void RemoveAll(int val)
    {
    }

    public int[] ToArray()
    {
        var newArray = new int[_ptr];

        for(int i = 0; i < _ptr; i++)
        {
            newArray[i] = _array[i];
        }

        return newArray;
    }

    private void Resize()
    {
        var newArray = new int[_array.Length * 2];

        for(int i = 0; i < _array.Length; i++)
        {
            newArray[i] = _array[i];
        }

        _array = newArray;
    }
}






