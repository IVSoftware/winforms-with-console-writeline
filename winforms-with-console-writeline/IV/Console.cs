
namespace System.IV
{
    static class Console
    {
        public static event ConsoleWriteEventHandler ConsoleWrite;
        public static void Write(object o) =>
            Console.ConsoleWrite?.Invoke(new ConsoleWriteEventArgs(o.ToString(), newLine: false));

        public static void WriteLine(object o) =>
            Console.ConsoleWrite?.Invoke(new ConsoleWriteEventArgs(o.ToString(), newLine: true));
    }

    public delegate void ConsoleWriteEventHandler(ConsoleWriteEventArgs e);
    public class ConsoleWriteEventArgs : EventArgs
    {
        public string Text { get; }
        public bool NewLine { get; }
        public ConsoleWriteEventArgs(string text, bool newLine)
        {
            Text = text;
            NewLine = newLine;
        }
    }
}
