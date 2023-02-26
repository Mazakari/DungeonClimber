public interface ISavedProgressReader
{
    void LoadProgress(PlayerProgress progress);
}

public interface ISavedProgress : ISavedProgressReader
{
    void UpdateProgress(PlayerProgress progress);
}

// TO DO Need to implement
//public interface ISavedProgressWriter
//{
//    void UpdateProgress(PlayerProgress progress);
//}
