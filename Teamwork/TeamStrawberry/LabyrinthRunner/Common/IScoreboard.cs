namespace LabyrinthRunner.Common
{
    public interface IScoreboard
    {
        void Add(string name, int points);

        bool IsScoreSavable(string name, int points);

        string Show();
    }
}
