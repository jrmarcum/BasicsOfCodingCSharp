var s = new[] { "foo", "bar", "zoo" };
Console.WriteLine("index of zoo: " + SlicesIndex(s, "zoo"));

var lst = new LinkedList<int>();
lst.Push(10);
lst.Push(13);
lst.Push(23);
Console.WriteLine("list: [" + string.Join(" ", lst.AllElements()) + "]");

static int SlicesIndex<T>(T[] arr, T v) where T : IEquatable<T>
{
    for (int i = 0; i < arr.Length; i++)
        if (v.Equals(arr[i])) return i;
    return -1;
}

class LinkedList<T>
{
    private class Element { public Element? Next; public T Val = default!; }
    private Element? head, tail;

    public void Push(T v)
    {
        var e = new Element { Val = v };
        if (tail == null) { head = e; tail = e; }
        else { tail.Next = e; tail = e; }
    }

    public IEnumerable<T> AllElements()
    {
        for (var e = head; e != null; e = e.Next)
            yield return e.Val;
    }
}
