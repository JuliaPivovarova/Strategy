namespace Code.Abstractions
{
    public interface IAwaitable<T>
    {
        IAwaiter<T> GetAwaiter();
    }
}