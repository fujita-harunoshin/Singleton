namespace Singleton;

/// <summary>
/// Singletonは、
/// ・クラスのインスタンスが一つだけであることを保証する
/// 　└ データベースやファイルなどの共有資源へのアクセスを制限できるのが、用いられる代表的な理由
/// ・インスタンスへの大域アクセスポイントを提供する
/// 　└ プログラム内のどこからでもオブジェクトのアクセスを許可すると同時に、そのインスタンスが他のコードによって変更されるのを防ぐ
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(
            "{0}\n{1}\n\n{2}\n",
            "If you see the same value, then singleton was reused (yay!)",
            "If you see different values, then 2 singletons were created (booo!!)",
            "RESULT:"
        );

        var process1 = new Thread(() =>
        {
            TestSingleton("FOO");
        });

        var process2 = new Thread(() =>
        {
            TestSingleton("BAR");
        });

        process1.Start();
        process2.Start();

        process1.Join();
        process2.Join();
    }

    public static void TestSingleton(string value)
    {
        var singleton = Singleton.GetInstance(value);
        Console.WriteLine(singleton.Value);
    }
}
