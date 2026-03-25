namespace WWPRevitToolBar.Ui
{
    internal sealed class SelectionItem<T>
    {
        public SelectionItem(string label, T value)
        {
            Label = label;
            Value = value;
        }

        public string Label { get; private set; }

        public T Value { get; private set; }

        public override string ToString()
        {
            return Label;
        }
    }
}
