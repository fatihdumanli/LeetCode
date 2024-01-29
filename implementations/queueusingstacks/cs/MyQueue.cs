namespace QueueUsingStacks;

public class MyQueue
{
    private const int PUSH = 0;
    private const int POP = 1;

    private readonly Stack<int> _mainStack;
    private readonly Stack<int> _secondaryStack;
    private int _lastOperation = PUSH;

    public MyQueue()
    {
        _mainStack = new Stack<int>();
        _secondaryStack = new Stack<int>();
    }

    public void Push(int x)
    {
        if (_lastOperation == POP)
        {
            while (_secondaryStack.Count > 0)
            {
                _mainStack.Push(_secondaryStack.Pop());
            }
        }

        _lastOperation = PUSH;
        _mainStack.Push(x);
    }

    public int Pop()
    {
        if (_lastOperation == PUSH)
        {
            while (_mainStack.Count > 0)
                _secondaryStack.Push(_mainStack.Pop());
        }


        _lastOperation = POP;
        return _secondaryStack.Pop();
    }

    public int Peek()
    {
        if (_lastOperation == PUSH)
        {
            while (_mainStack.Count > 0)
                _secondaryStack.Push(_mainStack.Pop());
        }

        _lastOperation = POP;
        return _secondaryStack.Peek();
    }

    public bool Empty()
    {
        return _mainStack.Count == 0 && _secondaryStack.Count == 0;
    }
}