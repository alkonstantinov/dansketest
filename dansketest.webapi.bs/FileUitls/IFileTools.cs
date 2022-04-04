namespace dansketest.webapi.bs.FileUitls
{
    public interface IFileTools
    {
        string ReadFile();
        void WriteToFile(string content);
    }
}