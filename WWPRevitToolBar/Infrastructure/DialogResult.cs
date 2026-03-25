namespace WWPRevitToolBar.Infrastructure
{
    internal sealed class DialogResult<T>
    {
        public bool Accepted { get; set; }

        public T Value { get; set; }
    }
}
