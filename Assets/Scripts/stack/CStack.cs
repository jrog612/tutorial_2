/*
 * 스택이 하는 일
 * - 선입후출 First In Last Out (FILO)
 */

public class CStack<T> where T : new()
{
    private StackNode<T> Top;

    public int Count { get; private set; }

    public void Push(T value)
    {
        var newNode = new StackNode<T>(value);
        newNode.Prev = Top;
        Top = newNode;
        Count++;
    }

    public T Pop()
    {
        if (Top == null) return new T();

        var target = Top;
        Top = target.Prev;
        target.Prev = null;
        Count--;
        return target.Data;
    }
}

public class StackNode<T>
{
    public T Data { get; }

    public StackNode<T> Prev;

    public StackNode(T data)
    {
        Data = data;
    }
}