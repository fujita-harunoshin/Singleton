namespace Singleton;

internal class Singleton
{
    private Singleton() { }

    private static Singleton _instance;

    private static readonly object _lock = new();

    public string Value { get; set; }

    public static Singleton GetInstance(string value)
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton
                    {
                        Value = value
                    };
                }
            }
        }
        return _instance;
    }
}
