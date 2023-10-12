namespace HalloSingelton
{
    internal class Logger
    {

        private static Logger? instance;
        private static readonly object instanceLock = new object();
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                    lock (instanceLock)
                    {
                        if (instance == null)
                            instance = new Logger();
                    }

                return instance;
            }
        }

        private Logger()
        {
            Info("New Logger");
        }

        public void Info(string message)
        {
            Console.WriteLine($"[{DateTime.Now:g}] INFO {message}");
        }

        public void Error(string message)
        {
            Console.WriteLine($"[{DateTime.Now:g}] ERROR {message}");
        }
    }
}
