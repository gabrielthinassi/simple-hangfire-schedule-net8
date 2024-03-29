namespace simple_hangfire_schedule_net8.Services
{
    public class FilePurge : IDisposable
    {
        public void Dispose()
        { }

        public void PurgeFromDirectory(string dirPath)
        {
            try
            {
                if (Directory.Exists(dirPath))
                {
                    string[] arquivos = Directory.GetFiles(dirPath);

                    foreach (string arquivo in arquivos)
                    {
                        File.Delete(arquivo);
                        Console.WriteLine($"Arquivo {arquivo} deletado com sucesso na pasta {dirPath}.");
                    }
                }
                else
                {
                    Console.WriteLine($"A pasta {dirPath} não existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
