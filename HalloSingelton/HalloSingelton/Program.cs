using HalloSingelton;

Console.WriteLine("Hello, World!");

Parallel.For(0, 10, i => Logger.Instance.Info($"GO {i}"));

Logger.Instance.Info("Hallo");

Logger.Instance.Error("PANIK!!!");
