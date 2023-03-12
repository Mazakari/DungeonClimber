public interface ILevelCellsService : IService
{
    LevelCell[] Levels { get; }
    LevelCell Current { get; }

    void InitService();
    void SaveCompletedLevel(bool artifactLocked);
    void SetCurrentCell();
    void UnlockNextLevel(string nextLevelName);
}